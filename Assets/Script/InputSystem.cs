
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TickEventSystem
{
    public class InputSystem : MonoBehaviour
    {
        public static InputActions inputActions;
        public List<TickEvent> tickEvents = new List<TickEvent>();

        private void Awake()
        {
            setInputManager();
            creatEventListener();
        }

        void Start()
        {
            TickEvent.setGameStartTime();
        }

        void setInputManager()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
            }
            inputActions.Enable();
        }

        void creatEventListener()
        {
            inputActions.InputMap_Keyboard.a.started += inputTickEvent;
            inputActions.InputMap_Keyboard.a.performed += inputTickEvent;
            inputActions.InputMap_Keyboard.a.canceled += inputTickEvent;
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