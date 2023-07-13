using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevTools.TickEventSystem
{
    public class ExamplePlayerManager : MonoBehaviour, TickUpdateObserver
    {
        public InputEventManager inputEventManager;
        public InputState inputState;
        void Start()
        {
            inputState = inputEventManager.inputState;
            inputEventManager.ticksLogic.AddObserver(this);
        }

        // Update is called once per frame
        public void TickUpdate()
        {

        }
    }
}