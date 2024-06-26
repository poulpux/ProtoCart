using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody))]
public partial class KartMovement : PlayerInputSystem
{
    private enum movementType
    {
        ACCELERATE,
        DECELERATE,
        DONOTHING,
        DRIFT,
        DASH
    }

    [Header("=====AccelerationAndDeceleration=====")]
    [Space(10)]
    [SerializeField] private float accelerationSpd;
    [SerializeField] private float decelerationSpd, doNothingSpd, driftSpd, dashSpd;

    [Header("=====MaxSpeed=====")]
    [Space(10)]
    [SerializeField] private float maxSpdFront;
    [SerializeField] private float dashMaxSpd, onContactMaxSpd, onPanadeMaxSpd, maxSpdBack, maxDriftSpd, limitVeloY;

    [Header("=====Maniability=====")]
    [Space(10)]
    [SerializeField] private float maniability;

    [Header("=====Duration=====")]
    [Space(10)]
    [SerializeField] private float dashDuration;
    public float dashCldwn, driftCldwn;

    [Header("=====Visu=====")]
    [Space(10)]
    [SerializeField] private MeshRenderer rendererr;
    
    [Header("=====Curve=====")]
    [Space(10)]
    [SerializeField] private AnimationCurve accelerationCurve;
    [SerializeField] private AnimationCurve decelerationCurve, doNothingCurve, driftCurve;


    [HideInInspector] public float dashTimer, velocity;
    private Rigidbody rb;
    private float timerDrift;
    private bool isOnAir, isDashing;

    private float saveMaxSpd, curveTimer, saveStartValue;

    protected override void Awake()
    {
        base.Awake();
        InstantiateAll();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        AllTimer();
        ThrowDash();
        SetVelocity();
        Rotate();
        GroudDistanceCalculation();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void GroudDistanceCalculation()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        isOnAir = Physics.Raycast(ray, out RaycastHit hit, distOnAir, ~(1 << LayerMask.NameToLayer("Player"))) ? false : true;
    }

    private void ThrowDash()
    {
        if (TryDash && dashTimer > dashCldwn)
        {
            velocity = maxSpdFront;
            dashTimer = 0;
            isDashing = true;
            StopCoroutine(Dash());
            StartCoroutine(Dash());
            TryDash = false;
        }

        if (isDashing)
            rendererr.material.color = new Color(1f, 100f / 255f, 0f);
    }

    private IEnumerator Dash()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rendererr.material.color = Color.white;
        yield break;
    }

    private void InstantiateAll()
    {
        drift.InitState(onDriftEnter, onDriftUpdate,onDriftFixedUpdate, onDriftExit); 
        accelerate.InitState(onAccelerateEnter, onAccelerateUpdate,onAccelerateFixedUpdate, onAccelerateExit); 
        goBack.InitState(onGoBackEnter, onGoBackUpdate,onGoBackFixedUpdate, onGoBackExit); 
        doNothing.InitState(onDoNothingEnter, onDoNothingUpdate,onDoNothingFixedUpdate, onDoNothingExit); 
        ForcedCurrentState(doNothing);

        rb = GetComponent<Rigidbody>();
    }

    private void ChangeVelocity(movementType moveType, float maxSpd)
    {
        AllVelocityExeption(ref moveType, ref maxSpd);
        AnimationCurve currentCurve = moveType == movementType.ACCELERATE ? accelerationCurve : 
                                      moveType == movementType.DECELERATE ? decelerationCurve : 
                                      moveType == movementType.DONOTHING ? doNothingCurve : driftCurve;

        curveTimer += Time.deltaTime / FindDuration(moveType);
        if (saveMaxSpd != maxSpd) //A chang� de mode
        {
            curveTimer = 0f;
            saveMaxSpd = maxSpd;
            saveStartValue = velocity;
        }

        velocity = curveTimer >= 1 ? saveMaxSpd : saveStartValue + currentCurve.Evaluate(curveTimer) * (saveMaxSpd - saveStartValue);
    }

    private float FindDuration(movementType moveType)
    {
        float coef = (saveMaxSpd - saveStartValue);
        if (moveType == movementType.ACCELERATE)
            return coef / accelerationSpd;
        else if (moveType == movementType.DECELERATE)
            return coef / decelerationSpd;
        else if (moveType == movementType.DONOTHING)
            return  Mathf.Abs(coef / doNothingSpd);
        else if (moveType == movementType.DRIFT)
            return Mathf.Abs(coef / driftSpd);
        else if(moveType == movementType.DASH)
            return coef / dashSpd;
        else
        {
            Debug.LogError("Error movement type enum : KartMovement");
            return 0f;
        }
    }

    private void AllVelocityExeption(ref movementType moveType, ref  float maxSpd)
    {
        if (isDashing)
        {
            moveType = movementType.DASH;
            maxSpd = dashMaxSpd;
        }
        else if (velocity > maxSpdFront)
        {
            moveType = movementType.DECELERATE;
        }
    }

    private void SetVelocity()
    {
       //Pour empecher qu'il s'envole
        rb.velocity = new Vector3(0f,rb.velocity.y > limitVeloY ? rb.velocity.y /2f : rb.velocity.y, 0f )+ transform.forward * velocity;
    }

    private void Rotate()
    {
         transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction.x + offSet * Time.deltaTime, 0f);
    }

    private void AllTimer()
    {
        timerDrift += Time.deltaTime;
        dashTimer += Time.deltaTime;
    }

    private void TryDrift()
    {
        if (timerDrift > driftCldwn && isDrifting && !isOnAir)
            ChangeState(drift);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            velocity = 0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Default") && velocity > onContactMaxSpd )
            velocity = onContactMaxSpd;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out"))
            ChangeState(doNothing);
    }
}