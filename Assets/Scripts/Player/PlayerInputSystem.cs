using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : StateManager
{
    //Toutes les variables interressantes ici
    //=======================================
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public bool isAccelerate, isDecelerate, isDrifting, TryDash;
    //=======================================


    private enum CONFIG
    {
        DEFAULT,
        TACTICAL,
        SWITCH
    }

    Control input;
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
        base.Update();

        if (Input.GetKeyDown(KeyCode.Keypad1))
            SwitchConfig(CONFIG.DEFAULT);
        else if (Input.GetKeyDown(KeyCode.Keypad2))
            SwitchConfig(CONFIG.TACTICAL);
        else if(Input.GetKeyDown(KeyCode.Keypad3))
            SwitchConfig(CONFIG.SWITCH);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected virtual void OnEnable()
    {
        input.Enable();

        DefaultEnable();
        SwitchEnable();
        TacticalEnable();

        SwitchConfig(config);
    }
    
    protected virtual void OnDisable()
    {
        input.Disable();

        DefaultDisable();
        SwitchDisable();
        TacticalDisable();
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void SwitchConfig(CONFIG config)
    {
        print(config.ToString());

        input.Default.Disable();
        input.Tactical.Disable();
        input.Switch.Disable();

        if (config == CONFIG.DEFAULT)
            input.Default.Enable();
        else if (config == CONFIG.TACTICAL)
            input.Tactical.Enable();
        else if (config == CONFIG.SWITCH)
            input.Switch.Enable();
    }

    private void GetDash(InputAction.CallbackContext value)
    {
        TryDash = value.ReadValue<float>() > 0;
    }

    private void DashSleep(InputAction.CallbackContext value)
    {
        TryDash = false;
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
        direction = value.ReadValue<Vector2>();
    }
    private void GetDirectionSleep(InputAction.CallbackContext value)
    {
        direction = Vector2.zero;
    }

    //J'arrive pas � simplifier �a avec l'input system. Chaque config � un type de classe propre et pas moyen de faire des appels g�n�raux ou d'utiliser un string 
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
        input.Default.Dash.performed += GetDash;
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
        input.Default.Dash.performed -= GetDash;
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
        input.Switch.Dash.performed += GetDash;
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
        input.Switch.Dash.performed -= GetDash;
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
        input.Tactical.Dash.performed += GetDash;
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
        input.Tactical.Dash.performed -= GetDash;
        input.Tactical.Dash.canceled -= DashSleep;
    }
}
