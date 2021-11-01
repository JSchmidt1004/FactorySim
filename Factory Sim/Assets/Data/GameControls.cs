// GENERATED AUTOMATICALLY FROM 'Assets/Data/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""0e4fb38d-71f2-4480-9b7c-7a1742012dc3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c6dbd39d-07e3-4640-870e-2ebf4bd3654a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d69dfda5-c0c1-4fdf-b6a2-2a7408622e85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""1ca2dff6-cbcd-4f55-bee5-e3698ebaf65b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""df58daa2-214e-449f-98c2-39f6ad67af06"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4ea54df3-5d2b-4b90-81fa-ee8a2ce05b15"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""8fa7cf06-b1b7-4743-bb30-732b85f6ffe6"",
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
                    ""id"": ""ed939299-1d4e-4c2d-9bb6-c1aa023b94d1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""086b24e6-0cd5-4cb2-b7ce-02ea9f3c4140"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bd483ab3-7087-495e-b2b2-c52b1494392f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b34249da-c10b-4c9a-9db0-92283caceda9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3911ea35-25f1-4390-8681-00181845368d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0298572d-77bd-43a4-b58e-a43399a861d9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""626b2656-3543-417b-bbab-c5b3da90fcf3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""066f7b06-df17-482c-bab6-3a33d50aa529"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ToolControls"",
            ""id"": ""e4a0fcf8-aeeb-43ab-a9e2-9d5f30da2a85"",
            ""actions"": [
                {
                    ""name"": ""PrimaryUse"",
                    ""type"": ""Button"",
                    ""id"": ""ee28afd0-f4dc-47e5-bdd2-23cc39140ec5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryUse"",
                    ""type"": ""Button"",
                    ""id"": ""46aba1f9-7286-45c5-89dd-b49995ed90f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7cf8ae28-7728-4916-8789-5eabff2b404a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltAction"",
                    ""type"": ""Button"",
                    ""id"": ""1c179010-49c6-4d62-9bde-e637dbcc1fa0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c958cf56-011c-401d-9750-412b6a6320d3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""PrimaryUse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91bd29ea-901a-4e50-a07a-7e65d2c07cda"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""SecondaryUse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0962322e-2f18-49e2-81bf-4c96e88a27cd"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79f8f47b-9373-4545-b803-f44a8ba9bfa4"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""AltAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControls"",
            ""id"": ""2caf1552-85db-4bd0-a531-0be5bcb9dc32"",
            ""actions"": [
                {
                    ""name"": ""CloseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ff580d9b-eb08-4630-a97a-265950e5363e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenBackpack"",
                    ""type"": ""Button"",
                    ""id"": ""27ee2772-0bec-415f-a2b9-735083c54364"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11a83c1a-2bd1-4bf0-937e-e16e38ec9534"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""CloseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd8af2ce-f806-420a-a043-37b67b5923ff"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""OpenBackpack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_Sprint = m_PlayerControls.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerControls_MouseX = m_PlayerControls.FindAction("MouseX", throwIfNotFound: true);
        m_PlayerControls_MouseY = m_PlayerControls.FindAction("MouseY", throwIfNotFound: true);
        // ToolControls
        m_ToolControls = asset.FindActionMap("ToolControls", throwIfNotFound: true);
        m_ToolControls_PrimaryUse = m_ToolControls.FindAction("PrimaryUse", throwIfNotFound: true);
        m_ToolControls_SecondaryUse = m_ToolControls.FindAction("SecondaryUse", throwIfNotFound: true);
        m_ToolControls_Scroll = m_ToolControls.FindAction("Scroll", throwIfNotFound: true);
        m_ToolControls_AltAction = m_ToolControls.FindAction("AltAction", throwIfNotFound: true);
        // MenuControls
        m_MenuControls = asset.FindActionMap("MenuControls", throwIfNotFound: true);
        m_MenuControls_CloseMenu = m_MenuControls.FindAction("CloseMenu", throwIfNotFound: true);
        m_MenuControls_OpenBackpack = m_MenuControls.FindAction("OpenBackpack", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_Sprint;
    private readonly InputAction m_PlayerControls_MouseX;
    private readonly InputAction m_PlayerControls_MouseY;
    public struct PlayerControlsActions
    {
        private @GameControls m_Wrapper;
        public PlayerControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @Sprint => m_Wrapper.m_PlayerControls_Sprint;
        public InputAction @MouseX => m_Wrapper.m_PlayerControls_MouseX;
        public InputAction @MouseY => m_Wrapper.m_PlayerControls_MouseY;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnSprint;
                @MouseX.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouseY;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // ToolControls
    private readonly InputActionMap m_ToolControls;
    private IToolControlsActions m_ToolControlsActionsCallbackInterface;
    private readonly InputAction m_ToolControls_PrimaryUse;
    private readonly InputAction m_ToolControls_SecondaryUse;
    private readonly InputAction m_ToolControls_Scroll;
    private readonly InputAction m_ToolControls_AltAction;
    public struct ToolControlsActions
    {
        private @GameControls m_Wrapper;
        public ToolControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryUse => m_Wrapper.m_ToolControls_PrimaryUse;
        public InputAction @SecondaryUse => m_Wrapper.m_ToolControls_SecondaryUse;
        public InputAction @Scroll => m_Wrapper.m_ToolControls_Scroll;
        public InputAction @AltAction => m_Wrapper.m_ToolControls_AltAction;
        public InputActionMap Get() { return m_Wrapper.m_ToolControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ToolControlsActions set) { return set.Get(); }
        public void SetCallbacks(IToolControlsActions instance)
        {
            if (m_Wrapper.m_ToolControlsActionsCallbackInterface != null)
            {
                @PrimaryUse.started -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnPrimaryUse;
                @PrimaryUse.performed -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnPrimaryUse;
                @PrimaryUse.canceled -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnPrimaryUse;
                @SecondaryUse.started -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnSecondaryUse;
                @SecondaryUse.performed -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnSecondaryUse;
                @SecondaryUse.canceled -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnSecondaryUse;
                @Scroll.started -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnScroll;
                @AltAction.started -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnAltAction;
                @AltAction.performed -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnAltAction;
                @AltAction.canceled -= m_Wrapper.m_ToolControlsActionsCallbackInterface.OnAltAction;
            }
            m_Wrapper.m_ToolControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryUse.started += instance.OnPrimaryUse;
                @PrimaryUse.performed += instance.OnPrimaryUse;
                @PrimaryUse.canceled += instance.OnPrimaryUse;
                @SecondaryUse.started += instance.OnSecondaryUse;
                @SecondaryUse.performed += instance.OnSecondaryUse;
                @SecondaryUse.canceled += instance.OnSecondaryUse;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @AltAction.started += instance.OnAltAction;
                @AltAction.performed += instance.OnAltAction;
                @AltAction.canceled += instance.OnAltAction;
            }
        }
    }
    public ToolControlsActions @ToolControls => new ToolControlsActions(this);

    // MenuControls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_CloseMenu;
    private readonly InputAction m_MenuControls_OpenBackpack;
    public struct MenuControlsActions
    {
        private @GameControls m_Wrapper;
        public MenuControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CloseMenu => m_Wrapper.m_MenuControls_CloseMenu;
        public InputAction @OpenBackpack => m_Wrapper.m_MenuControls_OpenBackpack;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @CloseMenu.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnCloseMenu;
                @CloseMenu.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnCloseMenu;
                @CloseMenu.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnCloseMenu;
                @OpenBackpack.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnOpenBackpack;
                @OpenBackpack.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnOpenBackpack;
                @OpenBackpack.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnOpenBackpack;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CloseMenu.started += instance.OnCloseMenu;
                @CloseMenu.performed += instance.OnCloseMenu;
                @CloseMenu.canceled += instance.OnCloseMenu;
                @OpenBackpack.started += instance.OnOpenBackpack;
                @OpenBackpack.performed += instance.OnOpenBackpack;
                @OpenBackpack.canceled += instance.OnOpenBackpack;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
    }
    public interface IToolControlsActions
    {
        void OnPrimaryUse(InputAction.CallbackContext context);
        void OnSecondaryUse(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnAltAction(InputAction.CallbackContext context);
    }
    public interface IMenuControlsActions
    {
        void OnCloseMenu(InputAction.CallbackContext context);
        void OnOpenBackpack(InputAction.CallbackContext context);
    }
}
