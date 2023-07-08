
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TickEventSystem
{
    /// <summary>
    /// 輸入資訊管理
    /// </summary>
    public class InputEventManager : MonoBehaviour
    {
        /// <summary>
        /// 須進行管理的InputActions
        /// </summary>
        public InputActions inputActions;
        /// <summary>
        /// 尚未處理的所有輸入事件
        /// </summary>
        public List<TickEvent> tickEvents = new List<TickEvent>();
        /// <summary>
        /// 輸入事件物件池
        /// </summary>
        public ObjPool<TickEvent> tickEventPool = new ObjPool<TickEvent>(30);

        private void Awake()
        {
            //開始遊戲時建立輸入器
            setInputManager();
        }

        void Start()
        {
            //紀錄遊戲開始時間為第0幀
            TickEvent.setGameStartTime();
            //開始遊戲時建立監聽器
            creatEventListener();
        }

        /// <summary>
        /// 確保有需管理的InputActions，並將它開啟
        /// </summary>
        void setInputManager()
        {
            if (inputActions == null)
            {
                inputActions = new InputActions();
            }
            inputActions.Enable();
        }

        /// <summary>
        /// 開啟所有InputActions監聽
        /// </summary>
        void creatEventListener()
        {
            inputActions.InputMap_Keyboard.a.started += inputTickEvent;
            inputActions.InputMap_Keyboard.a.performed += inputTickEvent;
            inputActions.InputMap_Keyboard.a.canceled += inputTickEvent;
        }

        /// <summary>
        /// 監聽回傳函式
        /// </summary>
        /// <param name="obj">input的監聽事件資訊</param>
        private void inputTickEvent(InputAction.CallbackContext obj)
        {
            TickEvent tickEvent = tickEventPool.newObject();
            tickEvent.setTickEvent(TickEvent.DataTimeToTick(), obj.phase.ToString());
            tickEvents.Add(tickEvent);
            Debug.LogWarning(tickEvent.eventContent + ", " + tickEvent.eventTriggerTick);
        }
        int i = 0;
        void Update()
        {
            print(tickEventPool.pool.Count);
        }
    }
}