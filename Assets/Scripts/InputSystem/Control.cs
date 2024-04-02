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
            ""name"": ""InputSystem"",
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
                    ""id"": ""9e6fe7ce-6fd6-4e1a-9880-437ed7ac060a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputSystem
        m_InputSystem = asset.FindActionMap("InputSystem", throwIfNotFound: true);
        m_InputSystem_Accelerate = m_InputSystem.FindAction("Accelerate", throwIfNotFound: true);
        m_InputSystem_Decelerate = m_InputSystem.FindAction("Decelerate", throwIfNotFound: true);
        m_InputSystem_Direction = m_InputSystem.FindAction("Direction", throwIfNotFound: true);
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

    // InputSystem
    private readonly InputActionMap m_InputSystem;
    private List<IInputSystemActions> m_InputSystemActionsCallbackInterfaces = new List<IInputSystemActions>();
    private readonly InputAction m_InputSystem_Accelerate;
    private readonly InputAction m_InputSystem_Decelerate;
    private readonly InputAction m_InputSystem_Direction;
    public struct InputSystemActions
    {
        private @Control m_Wrapper;
        public InputSystemActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_InputSystem_Accelerate;
        public InputAction @Decelerate => m_Wrapper.m_InputSystem_Decelerate;
        public InputAction @Direction => m_Wrapper.m_InputSystem_Direction;
        public InputActionMap Get() { return m_Wrapper.m_InputSystem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputSystemActions set) { return set.Get(); }
        public void AddCallbacks(IInputSystemActions instance)
        {
            if (instance == null || m_Wrapper.m_InputSystemActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputSystemActionsCallbackInterfaces.Add(instance);
            @Accelerate.started += instance.OnAccelerate;
            @Accelerate.performed += instance.OnAccelerate;
            @Accelerate.canceled += instance.OnAccelerate;
            @Decelerate.started += instance.OnDecelerate;
            @Decelerate.performed += instance.OnDecelerate;
            @Decelerate.canceled += instance.OnDecelerate;
            @Direction.started += instance.OnDirection;
            @Direction.performed += instance.OnDirection;
            @Direction.canceled += instance.OnDirection;
        }

        private void UnregisterCallbacks(IInputSystemActions instance)
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
        }

        public void RemoveCallbacks(IInputSystemActions instance)
        {
            if (m_Wrapper.m_InputSystemActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputSystemActions instance)
        {
            foreach (var item in m_Wrapper.m_InputSystemActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputSystemActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputSystemActions @InputSystem => new InputSystemActions(this);
    public interface IInputSystemActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDecelerate(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
    }
}
