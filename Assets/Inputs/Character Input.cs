//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Inputs/Character Input.inputactions
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

public partial class @CharacterInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Character Input"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""aa029d86-cc59-45c3-9f16-703185c1ed0a"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bb81c352-4e0f-452a-8e92-10773fcaf0a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""20cb2f09-40bc-4466-b8da-2eba2a967bf3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f5c8b21-6976-46ed-a8e1-bd0fa2d21b6d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45adee67-aadd-4b33-97d8-59f050846bbc"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16f9c023-2d6a-42f3-91fb-c1e56de7a10d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c743513-1b98-4acc-93d8-b3e7be0e7726"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1677e267-d67e-4f9e-ad1e-42f050fb7ff1"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbd40907-88ac-4f56-adc3-7f1d98bb9bfc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6308384-ecc0-4236-aa6f-397a0bc4b972"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6a98ffe-077a-4355-adaf-5382666c1f50"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d1548e8-c2e5-497b-9a03-b62a5a657578"",
                    ""path"": ""<XInputController>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1ee4586-65de-4005-b08a-b408c99822e8"",
                    ""path"": ""<DualShockGamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5698d407-4063-4894-8e4d-8cdd8efd9f02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0beab2b9-f6b6-4c2a-ada0-ea72e16e7c77"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e5f31124-2fa5-497d-bdee-950c114bc742"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""abea61fb-fa9e-4ac3-bac5-1e08d56d278f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89faa884-3586-44c3-9761-9d72c156efbe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Camera Movement"",
            ""id"": ""d3099429-4e23-4c60-a962-a4a4c460ead0"",
            ""actions"": [
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Value"",
                    ""id"": ""34a417eb-65f5-46ec-8cb1-4fe778a7bebf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ea7d569-93f7-49c5-9960-412d7ffb6540"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cf700af-6cb4-4bba-b70b-d49643423d7b"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d5ae092-25c5-4ea6-ac91-eaf998e42136"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Dash = m_PlayerMovement.FindAction("Dash", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        // Camera Movement
        m_CameraMovement = asset.FindActionMap("Camera Movement", throwIfNotFound: true);
        m_CameraMovement_LookAround = m_CameraMovement.FindAction("LookAround", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Dash;
    private readonly InputAction m_PlayerMovement_Move;
    public struct PlayerMovementActions
    {
        private @CharacterInput m_Wrapper;
        public PlayerMovementActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_PlayerMovement_Dash;
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Dash.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Camera Movement
    private readonly InputActionMap m_CameraMovement;
    private ICameraMovementActions m_CameraMovementActionsCallbackInterface;
    private readonly InputAction m_CameraMovement_LookAround;
    public struct CameraMovementActions
    {
        private @CharacterInput m_Wrapper;
        public CameraMovementActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LookAround => m_Wrapper.m_CameraMovement_LookAround;
        public InputActionMap Get() { return m_Wrapper.m_CameraMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraMovementActions set) { return set.Get(); }
        public void SetCallbacks(ICameraMovementActions instance)
        {
            if (m_Wrapper.m_CameraMovementActionsCallbackInterface != null)
            {
                @LookAround.started -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_CameraMovementActionsCallbackInterface.OnLookAround;
            }
            m_Wrapper.m_CameraMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
            }
        }
    }
    public CameraMovementActions @CameraMovement => new CameraMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface ICameraMovementActions
    {
        void OnLookAround(InputAction.CallbackContext context);
    }
}
