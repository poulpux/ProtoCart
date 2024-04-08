using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public enum CONFIG
{
    DEFAULT,
    TACTICAL,
    SWITCH
}

[RequireComponent(typeof(Rigidbody))]
public partial class KartMovement : StateManager
{
    [Header("=====SpeedAndControl=====")]
    [Space(10)]
    [SerializeField] private float decelerateSpd;
    [SerializeField] private float accelerateSpd, looseSpdDoNothing, looseSpdDrift,  maxSpdFront, onContactMaxSpd,onPanadeMaxSpd, maxSpdBack, maxDriftSpd, maniability, limitVeloY;

    [Header("=====Visu=====")]
    [Space(10)]
    [SerializeField] private MeshRenderer rendererr;

    Control input;
    private Rigidbody rb;
    private float velocity, direction, timerDrift;
    private bool isAccelerate, isDecelerate, isDrifting, isMuded, canDriftBUp, canDashBUp;

    [SerializeField] private CONFIG config;
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
        TryDrift();
        base.Update();
        AllTimer();
        SetVelocity();
        Rotate();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void ThrowDash()
    {
        StopCoroutine(Dash());
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
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
        input = new Control();
    }

    private void ChangeVelocity(float veloModifier, float maxSpd, float looseSpdTemp = 0f)
    {
        looseSpdTemp = looseSpdTemp == 0f ? looseSpdDoNothing : looseSpdTemp;
        if (isMuded)
        {
            maxSpd = onPanadeMaxSpd;
            looseSpdTemp = looseSpdDoNothing;
        }

        if (veloModifier < 0f)
            velocity = velocity + veloModifier * Time.deltaTime > maxSpd ? velocity + veloModifier * Time.deltaTime : velocity + looseSpdTemp * Time.deltaTime;
        else
            velocity = velocity + veloModifier * Time.deltaTime < maxSpd ? velocity + veloModifier * Time.deltaTime : velocity - looseSpdTemp * Time.deltaTime;
    }

    private void SetVelocity()
    {
       //Pour empecher qu'il s'envole
        rb.velocity = new Vector3(0f,rb.velocity.y > limitVeloY ? rb.velocity.y /2f : rb.velocity.y, 0f )+ transform.forward * velocity;
    }

    private void Rotate()
    {
         transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction + offSet, 0f);
    }

    private void AllTimer()
    {
        timerDrift += Time.deltaTime;
    }

    private void TryDrift()
    {
        if (timerDrift > 0.4f && GetState() != drift && isDrifting && canDriftBUp)
            Drift();
    }

    private void Drift()
    {
        ChangeState(drift);
        canDriftBUp = false;
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

    private void OnEnable()
    {
        input.Enable();

        if (config == CONFIG.DEFAULT)
            DefaultEnable();
    }

    private void OnDisable()
    {
        input.Disable();

        if(config == CONFIG.DEFAULT)
            DefaultDisable();
    }

    private void DefaultDisable()
    {
        input.Default.Accelerate.performed -= AccelerateActing;
        input.Default.Accelerate.canceled -= AccelerateSleep;
        input.Default.Decelerate.performed -= DecelerateActing;
        input.Default.Decelerate.canceled -= DecelerateSleep;
        input.Default.Direction.performed -= GetDirectionActing;
        input.Default.Direction.canceled -= GetDirectionSleep;
        input.Default.Drift.performed -= TryDrift;
        input.Default.Drift.canceled -= DriftSleep;
        input.Default.Dash.canceled -= TryDash;
        input.Default.Dash.canceled -= DashSleep;
    }

    private void DefaultEnable()
    {
        input.Default.Accelerate.performed += AccelerateActing;
        input.Default.Accelerate.canceled += AccelerateSleep;
        input.Default.Decelerate.performed += DecelerateActing;
        input.Default.Decelerate.canceled += DecelerateSleep;
        input.Default.Direction.performed += GetDirectionActing;
        input.Default.Direction.canceled += GetDirectionSleep;
        input.Default.Drift.performed += TryDrift;
        input.Default.Drift.canceled += DriftSleep;
        input.Default.Dash.canceled += TryDash;
        input.Default.Dash.canceled += DashSleep;
    }

    private void TryDash(InputAction.CallbackContext value)
    {
        if (value.ReadValue<float>() > 0 && canDashBUp)
            ThrowDash();
    }

    private void DashSleep(InputAction.CallbackContext value)
    {
        canDashBUp = true;
    }

    private void TryDrift(InputAction.CallbackContext value)
    {
        isDrifting = value.ReadValue<float>() > 0;
    }

    private void DriftSleep(InputAction.CallbackContext value)
    {
        isDrifting = false;
        canDriftBUp = true;
    }


    private void AccelerateActing(InputAction.CallbackContext value)
    {
        isAccelerate = value.ReadValue<float>() > 0;
    }

    private void AccelerateSleep(InputAction.CallbackContext value)
    {
        isAccelerate = false;
    }

    private void DecelerateActing(InputAction.CallbackContext value)
    {
        isDecelerate = value.ReadValue<float>() > 0;
    }
    
    private void DecelerateSleep(InputAction.CallbackContext value)
    {
        isDecelerate = false;
    }
    
    private void GetDirectionActing(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().x;
    }
    private void GetDirectionSleep(InputAction.CallbackContext value)
    {
        direction = 0f;
    }
}