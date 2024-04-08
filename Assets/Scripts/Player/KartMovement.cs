using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

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
    private bool isAccelerate, isDecelerate, isDrifting, isMuded, canDrift;
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
        if (timerDrift > 0.4f && GetState() != drift && isDrifting && canDrift)
            Drift();
    }

    private void Drift()
    {
        ChangeState(drift);
        canDrift = false;
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
        input.InputSystem.Accelerate.performed += AccelerateActing;
        input.InputSystem.Accelerate.canceled += AccelerateSleep;
        input.InputSystem.Decelerate.performed += DecelerateActing;
        input.InputSystem.Decelerate.canceled += DecelerateSleep;
        input.InputSystem.Direction.performed += GetDirectionActing;
        input.InputSystem.Direction.canceled += GetDirectionSleep;
        input.InputSystem.Drift.performed += TryDrift;
        input.InputSystem.Drift.canceled += DriftSleep;
    }

    private void OnDisable()
    {
        input.Disable();
        input.InputSystem.Accelerate.performed -= AccelerateActing;
        input.InputSystem.Accelerate.canceled -= AccelerateSleep;
        input.InputSystem.Decelerate.performed -= DecelerateActing;
        input.InputSystem.Decelerate.canceled -= DecelerateSleep;
        input.InputSystem.Direction.performed -= GetDirectionActing;
        input.InputSystem.Direction.canceled -= GetDirectionSleep;
        input.InputSystem.Drift.performed -= TryDrift;
        input.InputSystem.Drift.canceled -= DriftSleep;
    }
    private void TryDrift(InputAction.CallbackContext value)
    {
        isDrifting = value.ReadValue<float>() > 0;
    }

    private void DriftSleep(InputAction.CallbackContext value)
    {
        isDrifting = false;
        canDrift = true;
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