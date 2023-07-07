
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TickSystem
{
    public class InputEventSystem : MonoBehaviour
    {
        public static InputManager inputManager;
        public List<TickEvent> tickEvents = new List<TickEvent>();

        private void Awake()
        {
            setInputManager();
            creatEventListener();
            //inputManager.InputMap_Keyboard.a.canceled += keyValue => p(keyValue.canceled, "canceled");
        }

        void Start()
        {
            TickEvent.setGameStartTime();
        }

        void setInputManager()
        {
            if (inputManager == null)
            {
                inputManager = new InputManager();
            }
            inputManager.Enable();
        }

        void creatEventListener()
        {
            inputManager.InputMap_Keyboard.a.started += inputTickEvent;
            inputManager.InputMap_Keyboard.a.performed += inputTickEvent;
            inputManager.InputMap_Keyboard.a.canceled += inputTickEvent;
        }

        private void inputTickEvent(InputAction.CallbackContext obj)
        {
            TickEvent tickEvent = new TickEvent(TickEvent.DataTimeToTick(), obj.phase.ToString());
            tickEvents.Add(tickEvent);
            Debug.LogWarning(tickEvent.eventContent + ", " + tickEvent.eventTriggerTick);
        }
        int i = 0;
        void Update()
        {
            print("update : "+ i++);
        }
    }
}