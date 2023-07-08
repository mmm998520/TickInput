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
        /// 紀錄遊戲時間的計時器
        /// </summary>
        public TickTimer gameTickTimer;
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
            enableInputManager();
        }

        void Start()
        {
            //遊戲開始時開始計時
            if(gameTickTimer == null)
            {
                gameTickTimer = new TickTimer();
            }
            gameTickTimer.restartStopwatch();
            //開始遊戲時建立監聽器
            creatEventListener();
        }

        /// <summary>
        /// 確保有InputActions，並將它啟開
        /// </summary>
        void enableInputManager()
        {
            if(inputActions == null)
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
            tickEvent.setTickEvent(gameTickTimer.getRunTick(), obj.phase.ToString());
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