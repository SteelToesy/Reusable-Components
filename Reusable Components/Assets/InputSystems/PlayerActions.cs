//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystems/PlayerActions.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""29d157bd-edd2-489b-aa59-95779c0bb84c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""878b990e-6c15-4cb6-b5c1-4d545a6121fb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""fe9f0eeb-8ab5-410a-8297-46c0cca63111"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""ab617db6-b17e-4c78-9868-ca23aa273cfb"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Value"",
                    ""id"": ""3d272c93-91bf-4ead-b193-afb619b85a9c"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToggleFirerate"",
                    ""type"": ""Button"",
                    ""id"": ""f6ab85c3-7b46-4a7d-bd52-6ed422af3b02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""d5f531fe-63df-4826-8d1e-3e479892bb2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""91df5021-371f-4cc5-a907-819b7b116056"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9fbc8e5d-c7fd-4c30-af28-57de48def538"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""337e7151-c98c-45e2-ad06-c211a4df6379"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dbbe90e6-e326-4ae4-bccd-ca52353714c5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""73ed8d76-9297-4c28-884b-9299d66b04ec"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d04f541e-3fad-4e65-8ea1-fbd50a2b1b4b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e7722342-5993-4a97-9882-25e0c220d8d9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee26d3fe-17ca-4107-8fd5-96d1915c70fb"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cdd4a47-7fbd-4963-b677-22efc509280b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e62f3cc-d94c-4520-a36c-a6132062e169"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95c13e4f-a50a-477b-93c3-16d13260f419"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleFirerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abd2123a-a2e4-465b-8053-f662c5b41576"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b57c1bdb-e89d-4ad5-99c9-8f63bec65b32"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44f685de-2815-4cd0-b812-acefc887b991"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Movement = m_PlayerMap.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMap_Sprint = m_PlayerMap.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerMap_Fire = m_PlayerMap.FindAction("Fire", throwIfNotFound: true);
        m_PlayerMap_Reload = m_PlayerMap.FindAction("Reload", throwIfNotFound: true);
        m_PlayerMap_ToggleFirerate = m_PlayerMap.FindAction("ToggleFirerate", throwIfNotFound: true);
        m_PlayerMap_SwitchWeapon = m_PlayerMap.FindAction("SwitchWeapon", throwIfNotFound: true);
        m_PlayerMap_Interact = m_PlayerMap.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMap_Pause = m_PlayerMap.FindAction("Pause", throwIfNotFound: true);
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

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMap_Movement;
    private readonly InputAction m_PlayerMap_Sprint;
    private readonly InputAction m_PlayerMap_Fire;
    private readonly InputAction m_PlayerMap_Reload;
    private readonly InputAction m_PlayerMap_ToggleFirerate;
    private readonly InputAction m_PlayerMap_SwitchWeapon;
    private readonly InputAction m_PlayerMap_Interact;
    private readonly InputAction m_PlayerMap_Pause;
    public struct PlayerMapActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerMapActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMap_Movement;
        public InputAction @Sprint => m_Wrapper.m_PlayerMap_Sprint;
        public InputAction @Fire => m_Wrapper.m_PlayerMap_Fire;
        public InputAction @Reload => m_Wrapper.m_PlayerMap_Reload;
        public InputAction @ToggleFirerate => m_Wrapper.m_PlayerMap_ToggleFirerate;
        public InputAction @SwitchWeapon => m_Wrapper.m_PlayerMap_SwitchWeapon;
        public InputAction @Interact => m_Wrapper.m_PlayerMap_Interact;
        public InputAction @Pause => m_Wrapper.m_PlayerMap_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSprint;
                @Fire.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnReload;
                @ToggleFirerate.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnToggleFirerate;
                @ToggleFirerate.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnToggleFirerate;
                @ToggleFirerate.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnToggleFirerate;
                @SwitchWeapon.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSwitchWeapon;
                @Interact.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @ToggleFirerate.started += instance.OnToggleFirerate;
                @ToggleFirerate.performed += instance.OnToggleFirerate;
                @ToggleFirerate.canceled += instance.OnToggleFirerate;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnToggleFirerate(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
