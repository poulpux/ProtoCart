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
    [SerializeField] private float accelerateSpd, looseSpd, maxSpdFront, onContactMaxSpd,onPanadeMaxSpd, maxSpdBack, maniability, limitVeloY;

    [Header("=====Visu=====")]
    [Space(10)]
    [SerializeField] private MeshRenderer rendererr;

    Control input;
    private Rigidbody rb;
    private float velocity, direction, timerDrift;
    private bool isAccelerate, isDecelerate, isDrifting, onAir;
    private Transform cam;
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
        SetVelocity();
        Rotate();
        TryDrift();
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
        cam = FindObjectsByType<Camera>(FindObjectsSortMode.None)
            ?.First(o => o.gameObject.layer == LayerMask.NameToLayer("Player")).transform;
    }

    private void ChangeVelocity(float veloModifier, float maxSpd)
    {
        if(veloModifier < 0f)
            velocity = velocity + veloModifier* Time.deltaTime > maxSpd ? velocity + veloModifier * Time.deltaTime : maxSpd;
        else
            velocity = velocity + veloModifier * Time.deltaTime < maxSpd ? velocity + veloModifier * Time.deltaTime : maxSpd;
    }

    private void SetVelocity()
    {
       //Pour empecher qu'il s'envole
        rb.velocity = new Vector3(0f,rb.velocity.y > limitVeloY ? rb.velocity.y /2f : rb.velocity.y, 0f )+ transform.forward * velocity;
    }

    private void Rotate()
    {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + maniability * Time.deltaTime * direction, 0f);
    }

    private void AllTimer()
    {
        timerDrift += Time.deltaTime;
    }

    private void TryDrift()
    {
        if (timerDrift > 0.2f && GetState() != drift && isDrifting)
            Drift();
    }

    private void Drift()
    {
        ChangeState(drift);
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
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out") && velocity > onPanadeMaxSpd)
        {
            velocity = Mathf.Lerp(velocity, onPanadeMaxSpd, 1f);
            rendererr.material.color = new Color(80f / 255f, 33f / 255f, 0f); //brown
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Out"))
            ChangeState(doNothing);
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