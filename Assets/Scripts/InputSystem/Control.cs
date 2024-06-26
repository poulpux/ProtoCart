//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputSystem/Control.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Control: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""a8384924-846e-4530-9a07-430d66cf729f"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""1f544d98-7fa0-4008-9683-99cc98be4003"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Decelerate"",
                    ""type"": ""Button"",
                    ""id"": ""389a8210-6175-4f67-b4af-97deb32e0692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""2c25497e-0acd-4677-867b-ec347df55f70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""4489d9e6-9153-4395-9845-a1f6d714c9e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""86e80d2b-b372-4f9d-bcf7-8adf86f523be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""8e66bbb3-344a-41e5-b566-4a6d1d5852c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""90ef3eff-bab9-49b0-9a57-3d9f5ec25017"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d276d504-da7c-4658-8a4e-ba97fce655a7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5839634c-69c0-48ad-8a7b-8ddc051cf8e3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cb4533b-727e-4b03-b26e-26ed72efa18e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e6fe7ce-6fd6-4e1a-9880-437ed7ac060a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""830a6b04-5edb-4619-b9d7-6c7c23ec1d45"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d9669ac-d293-4a56-858a-8ecc38511dbf"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab6fb018-117b-434f-8f95-702effa55365"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Tactical"",
            ""id"": ""3040474b-3720-4278-9230-1b22ed86c79e"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""09997346-ff72-4567-9dfd-3782deec90fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""5e64ff9e-1c82-49cc-acc8-8852161a28a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""25081760-9b70-41f0-a4e6-c3fcdd471270"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""55feef22-659d-4229-a7c1-0866387e0841"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Decelerate"",
                    ""type"": ""Button"",
                    ""id"": ""09883627-a3a1-465d-a64f-651d65747ac4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""bdce2db4-d4c5-47ec-8955-a092accf64fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5045aba0-5828-4e8b-ac38-9a165aff6530"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d9c9493-44f5-485c-b52b-53310f92e8ea"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b110775-7f22-4a9d-a433-93634996eb18"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Switch"",
            ""id"": ""73ca0bae-7cf6-4206-b61c-45d0c9585ace"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e37ca9ff-cd59-45df-8b8c-8f91839a4d2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowObject"",
                    ""type"": ""Button"",
                    ""id"": ""8260e46f-7a04-4bdc-8555-0d56ca4d1eb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""733418f0-e89a-41b7-9c1a-e721a3404a3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""8503657f-fec4-436c-b12b-fa04561bd21c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Decelerate"",
                    ""type"": ""Button"",
                    ""id"": ""96ad91e2-9fc1-4dd8-8fdd-e187a66222ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""da8f0677-6c53-494a-9b38-2b61d0f485bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1df3095-29a4-4f3d-b928-b906a661aad8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09e49773-3b57-43b5-855b-b79ab35a030c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""717764dc-8b50-4871-8c4e-be82e840247a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3dcdd1e-66fe-42fc-983e-96d52978cf48"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""052e821c-4cfc-4acc-9bf9-23cd4f7206ce"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d97818a-5c0a-499b-abc5-bf4330036a79"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""234efa52-b4ac-4e1c-b5f4-21a30635ecb2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Accelerate = m_Default.FindAction("Accelerate", throwIfNotFound: true);
        m_Default_Decelerate = m_Default.FindAction("Decelerate", throwIfNotFound: true);
        m_Default_Direction = m_Default.FindAction("Direction", throwIfNotFound: true);
        m_Default_Drift = m_Default.FindAction("Drift", throwIfNotFound: true);
        m_Default_ThrowObject = m_Default.FindAction("ThrowObject", throwIfNotFound: true);
        m_Default_Dash = m_Default.FindAction("Dash", throwIfNotFound: true);
        // Tactical
        m_Tactical = asset.FindActionMap("Tactical", throwIfNotFound: true);
        m_Tactical_Dash = m_Tactical.FindAction("Dash", throwIfNotFound: true);
        m_Tactical_ThrowObject = m_Tactical.FindAction("ThrowObject", throwIfNotFound: true);
        m_Tactical_Drift = m_Tactical.FindAction("Drift", throwIfNotFound: true);
        m_Tactical_Direction = m_Tactical.FindAction("Direction", throwIfNotFound: true);
        m_Tactical_Decelerate = m_Tactical.FindAction("Decelerate", throwIfNotFound: true);
        m_Tactical_Accelerate = m_Tactical.FindAction("Accelerate", throwIfNotFound: true);
        // Switch
        m_Switch = asset.FindActionMap("Switch", throwIfNotFound: true);
        m_Switch_Dash = m_Switch.FindAction("Dash", throwIfNotFound: true);
        m_Switch_ThrowObject = m_Switch.FindAction("ThrowObject", throwIfNotFound: true);
        m_Switch_Drift = m_Switch.FindAction("Drift", throwIfNotFound: true);
        m_Switch_Direction = m_Switch.FindAction("Direction", throwIfNotFound: true);
        m_Switch_Decelerate = m_Switch.FindAction("Decelerate", throwIfNotFound: true);
        m_Switch_Accelerate = m_Switch.FindAction("Accelerate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Default
    private readonly InputActionMap m_Default;
    private List<IDefaultActions> m_DefaultActionsCallbackInterfaces = new List<IDefaultActions>();
    private readonly InputAction m_Default_Accelerate;
    private readonly InputAction m_Default_Decelerate;
    private readonly InputAction m_Default_Direction;
    private readonly InputAction m_Default_Drift;
    private readonly InputAction m_Default_ThrowObject;
    private readonly InputAction m_Default_Dash;
    public struct DefaultActions
    {
        private @Control m_Wrapper;
        public DefaultActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Default_Accelerate;
        public InputAction @Decelerate => m_Wrapper.m_Default_Decelerate;
        public InputAction @Direction => m_Wrapper.m_Default_Direction;
        public InputAction @Drift => m_Wrapper.m_Default_Drift;
        public InputAction @ThrowObject => m_Wrapper.m_Default_ThrowObject;
        public InputAction @Dash => m_Wrapper.m_Default_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void AddCallbacks(IDefaultActions instance)
        {
            if (instance == null || m_Wrapper.m_DefaultActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DefaultActionsCallbackInterfaces.Add(instance);
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @Decelerate.started += instance.OnDecelerate;
            @Decelerate.performed += instance.OnDecelerate;
            @Decelerate.canceled += instance.OnDecelerate;
            @Direction.started += instance.OnDirection;
            @Direction.performed += instance.OnDirection;
            @Direction.canceled += instance.OnDirection;
            @Drift.started += instance.OnDrift;
            @Drift.performed += instance.OnDrift;
            @Drift.canceled += instance.OnDrift;
            @ThrowObject.started += instance.OnThrowObject;
            @ThrowObject.performed += instance.OnThrowObject;
            @ThrowObject.canceled += instance.OnThrowObject;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IDefaultActions instance)
        {
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
            @Decelerate.started -= instance.OnDecelerate;
            @Decelerate.performed -= instance.OnDecelerate;
            @Decelerate.canceled -= instance.OnDecelerate;
            @Direction.started -= instance.OnDirection;
            @Direction.performed -= instance.OnDirection;
            @Direction.canceled -= instance.OnDirection;
            @Drift.started -= instance.OnDrift;
            @Drift.performed -= instance.OnDrift;
            @Drift.canceled -= instance.OnDrift;
            @ThrowObject.started -= instance.OnThrowObject;
            @ThrowObject.performed -= instance.OnThrowObject;
            @ThrowObject.canceled -= instance.OnThrowObject;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDefaultActions instance)
        {
            foreach (var item in m_Wrapper.m_DefaultActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DefaultActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DefaultActions @Default => new DefaultActions(this);

    // Tactical
    private readonly InputActionMap m_Tactical;
    private List<ITacticalActions> m_TacticalActionsCallbackInterfaces = new List<ITacticalActions>();
    private readonly InputAction m_Tactical_Dash;
    private readonly InputAction m_Tactical_ThrowObject;
    private readonly InputAction m_Tactical_Drift;
    private readonly InputAction m_Tactical_Direction;
    private readonly InputAction m_Tactical_Decelerate;
    private readonly InputAction m_Tactical_Accelerate;
    public struct TacticalActions
    {
        private @Control m_Wrapper;
        public TacticalActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Tactical_Dash;
        public InputAction @ThrowObject => m_Wrapper.m_Tactical_ThrowObject;
        public InputAction @Drift => m_Wrapper.m_Tactical_Drift;
        public InputAction @Direction => m_Wrapper.m_Tactical_Direction;
        public InputAction @Decelerate => m_Wrapper.m_Tactical_Decelerate;
        public InputAction @Accelerate => m_Wrapper.m_Tactical_Accelerate;
        public InputActionMap Get() { return m_Wrapper.m_Tactical; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TacticalActions set) { return set.Get(); }
        public void AddCallbacks(ITacticalActions instance)
        {
            if (instance == null || m_Wrapper.m_TacticalActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TacticalActionsCallbackInterfaces.Add(instance);
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @ThrowObject.started += instance.OnThrowObject;
            @ThrowObject.performed += instance.OnThrowObject;
            @ThrowObject.canceled += instance.OnThrowObject;
            @Drift.started += instance.OnDrift;
            @Drift.performed += instance.OnDrift;
            @Drift.canceled += instance.OnDrift;
            @Direction.started += instance.OnDirection;
            @Direction.performed += instance.OnDirection;
            @Direction.canceled += instance.OnDirection;
            @Decelerate.started += instance.OnDecelerate;
            @Decelerate.performed += instance.OnDecelerate;
            @Decelerate.canceled += instance.OnDecelerate;
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
        }

        private void UnregisterCallbacks(ITacticalActions instance)
        {
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @ThrowObject.started -= instance.OnThrowObject;
            @ThrowObject.performed -= instance.OnThrowObject;
            @ThrowObject.canceled -= instance.OnThrowObject;
            @Drift.started -= instance.OnDrift;
            @Drift.performed -= instance.OnDrift;
            @Drift.canceled -= instance.OnDrift;
            @Direction.started -= instance.OnDirection;
            @Direction.performed -= instance.OnDirection;
            @Direction.canceled -= instance.OnDirection;
            @Decelerate.started -= instance.OnDecelerate;
            @Decelerate.performed -= instance.OnDecelerate;
            @Decelerate.canceled -= instance.OnDecelerate;
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
        }

        public void RemoveCallbacks(ITacticalActions instance)
        {
            if (m_Wrapper.m_TacticalActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITacticalActions instance)
        {
            foreach (var item in m_Wrapper.m_TacticalActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TacticalActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TacticalActions @Tactical => new TacticalActions(this);

    // Switch
    private readonly InputActionMap m_Switch;
    private List<ISwitchActions> m_SwitchActionsCallbackInterfaces = new List<ISwitchActions>();
    private readonly InputAction m_Switch_Dash;
    private readonly InputAction m_Switch_ThrowObject;
    private readonly InputAction m_Switch_Drift;
    private readonly InputAction m_Switch_Direction;
    private readonly InputAction m_Switch_Decelerate;
    private readonly InputAction m_Switch_Accelerate;
    public struct SwitchActions
    {
        private @Control m_Wrapper;
        public SwitchActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Switch_Dash;
        public InputAction @ThrowObject => m_Wrapper.m_Switch_ThrowObject;
        public InputAction @Drift => m_Wrapper.m_Switch_Drift;
        public InputAction @Direction => m_Wrapper.m_Switch_Direction;
        public InputAction @Decelerate => m_Wrapper.m_Switch_Decelerate;
        public InputAction @Accelerate => m_Wrapper.m_Switch_Accelerate;
        public InputActionMap Get() { return m_Wrapper.m_Switch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwitchActions set) { return set.Get(); }
        public void AddCallbacks(ISwitchActions instance)
        {
            if (instance == null || m_Wrapper.m_SwitchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SwitchActionsCallbackInterfaces.Add(instance);
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @ThrowObject.started += instance.OnThrowObject;
            @ThrowObject.performed += instance.OnThrowObject;
            @ThrowObject.canceled += instance.OnThrowObject;
            @Drift.started += instance.OnDrift;
            @Drift.performed += instance.OnDrift;
            @Drift.canceled += instance.OnDrift;
            @Direction.started += instance.OnDirection;
            @Direction.performed += instance.OnDirection;
            @Direction.canceled += instance.OnDirection;
            @Decelerate.started += instance.OnDecelerate;
            @Decelerate.performed += instance.OnDecelerate;
            @Decelerate.canceled += instance.OnDecelerate;
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
        }

        private void UnregisterCallbacks(ISwitchActions instance)
        {
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @ThrowObject.started -= instance.OnThrowObject;
            @ThrowObject.performed -= instance.OnThrowObject;
            @ThrowObject.canceled -= instance.OnThrowObject;
            @Drift.started -= instance.OnDrift;
            @Drift.performed -= instance.OnDrift;
            @Drift.canceled -= instance.OnDrift;
            @Direction.started -= instance.OnDirection;
            @Direction.performed -= instance.OnDirection;
            @Direction.canceled -= instance.OnDirection;
            @Decelerate.started -= instance.OnDecelerate;
            @Decelerate.performed -= instance.OnDecelerate;
            @Decelerate.canceled -= instance.OnDecelerate;
            @Accelerate.started -= instance.OnAccelerate;
            @Accelerate.performed -= instance.OnAccelerate;
            @Accelerate.canceled -= instance.OnAccelerate;
        }

        public void RemoveCallbacks(ISwitchActions instance)
        {
            if (m_Wrapper.m_SwitchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISwitchActions instance)
        {
            foreach (var item in m_Wrapper.m_SwitchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SwitchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SwitchActions @Switch => new SwitchActions(this);
    public interface IDefaultActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDecelerate(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnThrowObject(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface ITacticalActions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnThrowObject(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnDecelerate(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
    }
    public interface ISwitchActions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnThrowObject(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
        void OnDecelerate(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
    }
}
