// GENERATED AUTOMATICALLY FROM 'Assets/Script/InputSystem/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""InputMap_Keyboard"",
            ""id"": ""f8d07b69-116a-4aa4-9436-a1f577953e75"",
            ""actions"": [
                {
                    ""name"": ""a"",
                    ""type"": ""Button"",
                    ""id"": ""61744e48-d32f-4453-adf8-734d89070c4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""twoAxis"",
                    ""type"": ""Value"",
                    ""id"": ""42e585fc-4424-4081-9763-7f55c0e13694"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a193377c-2b9e-46b8-93c5-1be156818c3b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""a"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78438ec2-499e-48b1-887d-8b8edcc65c9e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""a"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""KeyBoard_Arrow"",
                    ""id"": ""b151c7a3-89f3-42df-8214-1e8040b8605e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""twoAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a0d8b548-f27a-40de-ad66-d1e9653c5e71"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""twoAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2ef4a042-0148-4870-a649-e58e0cdfd035"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""twoAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1b4b8a6a-d752-4ffc-a225-c23f63ee8c50"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""twoAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5c750625-2bfb-411a-be42-8499a6ff81f8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""twoAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b122c708-7a67-4494-b315-6c252af463fd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""twoAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92452985-7abc-41bd-87ba-ebda3951307e"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""twoAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // InputMap_Keyboard
        m_InputMap_Keyboard = asset.FindActionMap("InputMap_Keyboard", throwIfNotFound: true);
        m_InputMap_Keyboard_a = m_InputMap_Keyboard.FindAction("a", throwIfNotFound: true);
        m_InputMap_Keyboard_twoAxis = m_InputMap_Keyboard.FindAction("twoAxis", throwIfNotFound: true);
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

    // InputMap_Keyboard
    private readonly InputActionMap m_InputMap_Keyboard;
    private IInputMap_KeyboardActions m_InputMap_KeyboardActionsCallbackInterface;
    private readonly InputAction m_InputMap_Keyboard_a;
    private readonly InputAction m_InputMap_Keyboard_twoAxis;
    public struct InputMap_KeyboardActions
    {
        private @InputManager m_Wrapper;
        public InputMap_KeyboardActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @a => m_Wrapper.m_InputMap_Keyboard_a;
        public InputAction @twoAxis => m_Wrapper.m_InputMap_Keyboard_twoAxis;
        public InputActionMap Get() { return m_Wrapper.m_InputMap_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputMap_KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IInputMap_KeyboardActions instance)
        {
            if (m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface != null)
            {
                @a.started -= m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface.OnA;
                @a.performed -= m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface.OnA;
                @a.canceled -= m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface.OnA;
                @twoAxis.started -= m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface.OnTwoAxis;
                @twoAxis.performed -= m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface.OnTwoAxis;
                @twoAxis.canceled -= m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface.OnTwoAxis;
            }
            m_Wrapper.m_InputMap_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @a.started += instance.OnA;
                @a.performed += instance.OnA;
                @a.canceled += instance.OnA;
                @twoAxis.started += instance.OnTwoAxis;
                @twoAxis.performed += instance.OnTwoAxis;
                @twoAxis.canceled += instance.OnTwoAxis;
            }
        }
    }
    public InputMap_KeyboardActions @InputMap_Keyboard => new InputMap_KeyboardActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IInputMap_KeyboardActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnTwoAxis(InputAction.CallbackContext context);
    }
}
