using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody))]
public partial class KartMovement : StateManager
{
    [Header("=====SpeedAndControl=====")]
    [Space(10)]
    [SerializeField] private float decelerateSpd;
    [SerializeField] private float accelerateSpd, looseSpd, maxSpdFront, onContactMaxSpd,onPanadeMaxSpd, maxSpdBack, maniability, limitVeloY;

    private Rigidbody rb;
    private float velocity, direction;

    Control input;
    private bool isAccelerate, isDecelerate;
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

    private void SetVelocity()
    {
       //Pour empecher qu'il s'envole
        rb.velocity = new Vector3(0f,rb.velocity.y > limitVeloY ? rb.velocity.y /2f : rb.velocity.y, 0f )+ transform.forward * velocity;
    }

    private void LooseSpd()
    {
        if(velocity > 0)
            velocity = velocity - looseSpd * Time.deltaTime < 0 ? 0 : velocity - looseSpd * Time.deltaTime;
        else
            velocity = velocity + looseSpd * Time.deltaTime > 0 ? 0 : velocity + looseSpd * Time.deltaTime;
    }

    private void Rotate()
    {
        if(velocity >= 0f)
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction, 0f);
        else
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction, 0f);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer != LayerMask.NameToLayer("Slide"))
            velocity = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Default") && velocity > onContactMaxSpd )
            velocity = onContactMaxSpd;
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Out") && velocity > onPanadeMaxSpd )
            velocity = Mathf.Lerp(velocity, onPanadeMaxSpd, 1f);
    }
}