using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody))]
public partial class KartMovement : PlayerInputSystem
{
    [Header("=====AccelerationAndDeceleration=====")]
    [Space(10)]
    [SerializeField] private float decelerateSpd;
    [SerializeField] private float accelerateSpd, dashSpd, looseSpdDoNothing, looseSpdDrift, dashDecelerate;

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
    [SerializeField] private float accelerationDuration;
    public float dashCldwn;

    [Header("=====Visu=====")]
    [Space(10)]
    [SerializeField] private MeshRenderer rendererr;
    
    [Header("=====Curve=====")]
    [Space(10)]
    [SerializeField] private AnimationCurve accelerationCurve;


    [HideInInspector] public float dashTimer, velocity;
    private Rigidbody rb;
    private float timerDrift;
    private bool isMuded, isOnAir, isDashing;

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
            velocity = velocity < 0f ? 0f : velocity;
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

    private void ChangeVelocity(float veloModifier, float maxSpd, float looseSpdTemp = 0f)
    {
        looseSpdTemp = looseSpdTemp == 0f ? looseSpdDoNothing : looseSpdTemp;

        AllVelocityExeption(ref veloModifier,ref maxSpd,ref looseSpdTemp);

        if (veloModifier < 0f)
        {
            curveTimer = 0f;
            maxSpd = -1f;
            velocity = velocity + veloModifier * Time.deltaTime > maxSpd ? velocity + veloModifier * Time.deltaTime : velocity + looseSpdTemp * Time.deltaTime;
        }
        if (veloModifier >= 0f)
        {
            curveTimer += Time.deltaTime / accelerationDuration;
            if(saveMaxSpd != maxSpd)
            {
                curveTimer = 0f;
                saveMaxSpd = maxSpd;
                saveStartValue = velocity;
                //ReplayCurve
            }
            
            velocity = saveStartValue + accelerationCurve.Evaluate(curveTimer) * (saveMaxSpd - saveStartValue);
            
        }
    }

    private void AllVelocityExeption(ref float veloModifier,ref  float maxSpd,ref float looseSpdTemp)
    {
        if (isMuded && !isDashing)
        {
            maxSpd = onPanadeMaxSpd;
            looseSpdTemp = looseSpdDoNothing;
        }

        if (isDashing)
        {
            veloModifier = dashSpd;
            maxSpd = dashMaxSpd;
        }
        else if (velocity > maxSpdFront)
            looseSpdTemp = dashDecelerate;
    }

    private void SetVelocity()
    {
       //Pour empecher qu'il s'envole
        rb.velocity = new Vector3(0f,rb.velocity.y > limitVeloY ? rb.velocity.y /2f : rb.velocity.y, 0f )+ transform.forward * velocity;
    }

    private void Rotate()
    {
         transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction + offSet * Time.deltaTime, 0f);
    }

    private void AllTimer()
    {
        timerDrift += Time.deltaTime;
        dashTimer += Time.deltaTime;
    }

    private void TryDrift()
    {
        if (timerDrift > 0.4f  && isDrifting && !isOnAir)
            ChangeState(drift);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
            velocity = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Default") && velocity > onContactMaxSpd )
            velocity = onContactMaxSpd;
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out") && velocity > onPanadeMaxSpd)
        {
            rendererr.material.color = new Color(80f / 255f, 33f / 255f, 0f); //brown
            isMuded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out"))
        {
            ChangeState(doNothing);
            isMuded = false;
        }
    }
}