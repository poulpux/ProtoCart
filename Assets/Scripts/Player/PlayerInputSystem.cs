using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : StateManager
{
    private enum CONFIG
    {
        DEFAULT,
        TACTICAL,
        SWITCH
    }

    Control input;
    protected float direction;
    protected bool isAccelerate, isDecelerate, isDrifting, isDashing;
    private bool canDashBUp, canDriftBUp;
    [Header("=====CONFIG=====")]
    [Space(10)]
    [SerializeField] private CONFIG config;

    protected override void Awake()
    {
        base.Awake();
        input = new Control();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            SwitchConfig(CONFIG.DEFAULT);
        else if (Input.GetKeyDown(KeyCode.Keypad2))
            SwitchConfig(CONFIG.TACTICAL);
        else if(Input.GetKeyDown(KeyCode.Keypad3))
            SwitchConfig(CONFIG.SWITCH);
        base.Update();

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected virtual void OnEnable()
    {
        input.Enable();

        if (config == CONFIG.DEFAULT)
            DefaultEnable();
        else if(config == CONFIG.SWITCH)
            SwitchEnable();
        else if(config==CONFIG.TACTICAL)
            TacticalEnable();
    }
    
    protected virtual void OnDisable()
    {
        input.Disable();

        if (config == CONFIG.DEFAULT)
            DefaultDisable();
        else if (config == CONFIG.SWITCH)
            SwitchDisable();
        else if( config==CONFIG.TACTICAL)
            TacticalDisable();

    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void SwitchConfig(CONFIG config)
    {
        print(config.ToString());
        if (this.config == CONFIG.DEFAULT)
            DefaultDisable();
        else if(this.config == CONFIG.TACTICAL)
            TacticalDisable();
        else if(this.config == CONFIG.SWITCH)
            SwitchDisable();

        if (config == CONFIG.DEFAULT)
            DefaultEnable();
        else if (config == CONFIG.TACTICAL)
            TacticalEnable();
        else if (config == CONFIG.SWITCH)
            SwitchEnable();
    }

    private void GetDash(InputAction.CallbackContext value)
    {
        if (canDashBUp)
        {
            canDashBUp = false;
            isDashing = value.ReadValue<float>() > 0;
        }
    }

    private void DashSleep(InputAction.CallbackContext value)
    {
        isDashing = false;
        canDashBUp = true;
    }

    private void TryDrift(InputAction.CallbackContext value)
    {
        if (canDriftBUp)
        {
            canDriftBUp = false;
            isDrifting = value.ReadValue<float>() > 0;
        }
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
        input.Default.Dash.canceled += GetDash;
        input.Default.Dash.canceled += DashSleep;
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
        input.Default.Dash.canceled -= GetDash;
        input.Default.Dash.canceled -= DashSleep;
    }

    private void SwitchEnable()
    {
        input.Switch.Accelerate.performed += AccelerateActing;
        input.Switch.Accelerate.canceled += AccelerateSleep;
        input.Switch.Decelerate.performed += DecelerateActing;
        input.Switch.Decelerate.canceled += DecelerateSleep;
        input.Switch.Direction.performed += GetDirectionActing;
        input.Switch.Direction.canceled += GetDirectionSleep;
        input.Switch.Drift.performed += TryDrift;
        input.Switch.Drift.canceled += DriftSleep;
        input.Switch.Dash.canceled += GetDash;
        input.Switch.Dash.canceled += DashSleep;
    }

    private void SwitchDisable()
    {
        input.Switch.Accelerate.performed -= AccelerateActing;
        input.Switch.Accelerate.canceled -= AccelerateSleep;
        input.Switch.Decelerate.performed -= DecelerateActing;
        input.Switch.Decelerate.canceled -= DecelerateSleep;
        input.Switch.Direction.performed -= GetDirectionActing;
        input.Switch.Direction.canceled -= GetDirectionSleep;
        input.Switch.Drift.performed -= TryDrift;
        input.Switch.Drift.canceled -= DriftSleep;
        input.Switch.Dash.canceled -= GetDash;
        input.Switch.Dash.canceled -= DashSleep;
    }

    private void TacticalEnable()
    {
        input.Tactical.Accelerate.performed += AccelerateActing;
        input.Tactical.Accelerate.canceled += AccelerateSleep;
        input.Tactical.Decelerate.performed += DecelerateActing;
        input.Tactical.Decelerate.canceled += DecelerateSleep;
        input.Tactical.Direction.performed += GetDirectionActing;
        input.Tactical.Direction.canceled += GetDirectionSleep;
        input.Tactical.Drift.performed += TryDrift;
        input.Tactical.Drift.canceled += DriftSleep;
        input.Tactical.Dash.canceled += GetDash;
        input.Tactical.Dash.canceled += DashSleep;
    }

    private void TacticalDisable()
    {
        input.Tactical.Accelerate.performed -= AccelerateActing;
        input.Tactical.Accelerate.canceled -= AccelerateSleep;
        input.Tactical.Decelerate.performed -= DecelerateActing;
        input.Tactical.Decelerate.canceled -= DecelerateSleep;
        input.Tactical.Direction.performed -= GetDirectionActing;
        input.Tactical.Direction.canceled -= GetDirectionSleep;
        input.Tactical.Drift.performed -= TryDrift;
        input.Tactical.Drift.canceled -= DriftSleep;
        input.Tactical.Dash.canceled -= GetDash;
        input.Tactical.Dash.canceled -= DashSleep;
    }
}
