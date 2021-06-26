// GENERATED AUTOMATICALLY FROM 'Assets/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace AsteroidsTestProject
{
    public class @InputControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9e77e590-e508-45d5-936a-de8720c96c1a"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""fe4d6fac-4ec0-4d06-a76e-b1d91dcdb80b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""59055957-d1a3-4c34-84ca-8a5a3e47f29b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Laser"",
                    ""type"": ""Button"",
                    ""id"": ""ed423c1f-6f52-4221-96da-64b03808ff45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""xAxis"",
                    ""type"": ""Value"",
                    ""id"": ""2d5f793d-38d2-42a6-9472-934731e8e8ed"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0de6f157-b9c8-4a7b-922c-056f9c6ca5b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81dfb749-3737-4878-9aed-d8a7b2351dc8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31c87e9e-14ef-4189-83e2-aa0db176c0f0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""834aee9a-2bda-4e04-921a-7b0d51056805"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Laser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ebef0aa6-75f4-48f6-88aa-586743fd0272"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c83a169e-f49c-4441-8d0e-21421db0dee4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0479190c-4e06-4e6e-97b4-ae8a9c8ede90"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a1d9bf10-34f2-42b0-b867-25dc9b8e8f4d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""70fdec02-acb7-4786-bef7-da72ec5ff832"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c461d86-c76c-4642-a6e4-07b92e4d71d6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""xAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""World"",
            ""id"": ""fe666677-a2a9-46f6-ab25-32aa53d68d27"",
            ""actions"": [
                {
                    ""name"": ""ChangeViewState"",
                    ""type"": ""Button"",
                    ""id"": ""bddd8a19-ab2d-4548-9ca4-5cdf158b5390"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1264e9a-b74d-4e45-9f4f-dcd7d87f9ad7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeViewState"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Up = m_Player.FindAction("Up", throwIfNotFound: true);
            m_Player_Shot = m_Player.FindAction("Shot", throwIfNotFound: true);
            m_Player_Laser = m_Player.FindAction("Laser", throwIfNotFound: true);
            m_Player_xAxis = m_Player.FindAction("xAxis", throwIfNotFound: true);
            // World
            m_World = asset.FindActionMap("World", throwIfNotFound: true);
            m_World_ChangeViewState = m_World.FindAction("ChangeViewState", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Up;
        private readonly InputAction m_Player_Shot;
        private readonly InputAction m_Player_Laser;
        private readonly InputAction m_Player_xAxis;
        public struct PlayerActions
        {
            private @InputControls m_Wrapper;
            public PlayerActions(@InputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Up => m_Wrapper.m_Player_Up;
            public InputAction @Shot => m_Wrapper.m_Player_Shot;
            public InputAction @Laser => m_Wrapper.m_Player_Laser;
            public InputAction @xAxis => m_Wrapper.m_Player_xAxis;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Up.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUp;
                    @Up.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUp;
                    @Up.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUp;
                    @Shot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                    @Shot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                    @Shot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                    @Laser.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLaser;
                    @Laser.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLaser;
                    @Laser.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLaser;
                    @xAxis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXAxis;
                    @xAxis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXAxis;
                    @xAxis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXAxis;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Up.started += instance.OnUp;
                    @Up.performed += instance.OnUp;
                    @Up.canceled += instance.OnUp;
                    @Shot.started += instance.OnShot;
                    @Shot.performed += instance.OnShot;
                    @Shot.canceled += instance.OnShot;
                    @Laser.started += instance.OnLaser;
                    @Laser.performed += instance.OnLaser;
                    @Laser.canceled += instance.OnLaser;
                    @xAxis.started += instance.OnXAxis;
                    @xAxis.performed += instance.OnXAxis;
                    @xAxis.canceled += instance.OnXAxis;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // World
        private readonly InputActionMap m_World;
        private IWorldActions m_WorldActionsCallbackInterface;
        private readonly InputAction m_World_ChangeViewState;
        public struct WorldActions
        {
            private @InputControls m_Wrapper;
            public WorldActions(@InputControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ChangeViewState => m_Wrapper.m_World_ChangeViewState;
            public InputActionMap Get() { return m_Wrapper.m_World; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WorldActions set) { return set.Get(); }
            public void SetCallbacks(IWorldActions instance)
            {
                if (m_Wrapper.m_WorldActionsCallbackInterface != null)
                {
                    @ChangeViewState.started -= m_Wrapper.m_WorldActionsCallbackInterface.OnChangeViewState;
                    @ChangeViewState.performed -= m_Wrapper.m_WorldActionsCallbackInterface.OnChangeViewState;
                    @ChangeViewState.canceled -= m_Wrapper.m_WorldActionsCallbackInterface.OnChangeViewState;
                }
                m_Wrapper.m_WorldActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ChangeViewState.started += instance.OnChangeViewState;
                    @ChangeViewState.performed += instance.OnChangeViewState;
                    @ChangeViewState.canceled += instance.OnChangeViewState;
                }
            }
        }
        public WorldActions @World => new WorldActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnUp(InputAction.CallbackContext context);
            void OnShot(InputAction.CallbackContext context);
            void OnLaser(InputAction.CallbackContext context);
            void OnXAxis(InputAction.CallbackContext context);
        }
        public interface IWorldActions
        {
            void OnChangeViewState(InputAction.CallbackContext context);
        }
    }
}
