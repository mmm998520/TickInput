using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameDevTools.General;

namespace GameDevTools.TickEventSystem
{
    /// <summary>
    /// 輸入資訊管理
    /// </summary>
    public class InputEventManager : MonoBehaviour
    {
        /// <summary>
        /// 須進行管理的InputActions
        /// </summary>
        [HideInInspector] public InputActions inputActions;
        /// <summary>
        /// 紀錄遊戲時間的計時器
        /// </summary>
        [HideInInspector] public TickTimer gameTickTimer;
        /// <summary>
        /// 尚未處理的所有輸入事件
        /// </summary>
        [HideInInspector] public List<TickInputEvent> tickInputEventsBuffer = new List<TickInputEvent>();
        /// <summary>
        /// 輸入事件物件池
        /// </summary>
        [HideInInspector] public ObjPool<TickInputEvent> tickInputEventPool = new ObjPool<TickInputEvent>(30);
        /// <summary>
        /// 邏輯幀運算器
        /// </summary>
        [HideInInspector] public TicksLogic ticksLogic;

        /// <summary>
        /// 輸入設定，定義該控制器的基本參數
        /// </summary>
        public InputSelcetOption inputSelcetOption;

        private void Awake()
        {
            //開啟前檢查inputSelcetOption是否有填入
            checkInputSelcetOption();
            //開始遊戲時建立輸入器
            enableInputManager();
        }

        void Start()
        {
            //遊戲開始時開始計時
            restartGameTickTimer();
            //遊戲開始時建立監聽器
            creatEventListener();
            //遊戲開始時邏輯幀運算器
            setTicksLogic();
        }

        void Update()
        {
            //在每個Update的最前面運算所有邏輯幀
            runTicksLogic();
        }

        /// <summary>
        /// 卻保有填入inputSelcetOption
        /// </summary>
        void checkInputSelcetOption()
        {
            if (inputSelcetOption == null)
            {
                inputSelcetOption = new InputSelcetOption();
            }
        }

        /// <summary>
        /// 確保有計時器，並開始計時
        /// </summary>
        void restartGameTickTimer()
        {
            if (gameTickTimer == null)
            {
                gameTickTimer = new TickTimer(inputSelcetOption.oneTickTime);
            }
            gameTickTimer.restartStopwatch();
        }
        
        /// <summary>
        /// 確保有邏輯運算器，並將運算器掛上本InputEventManager
        /// </summary>
        void setTicksLogic()
        {
            if(ticksLogic == null)
            {
                ticksLogic = new TicksLogic();
            }
            ticksLogic.inputEventManager = this;
        }

        /// <summary>
        /// 確保有InputActions，並將它啟開
        /// </summary>
        void enableInputManager()
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
            inputActions.InputMap_Keyboard.a.canceled += inputTickEvent;
        }

        /// <summary>
        /// 監聽回傳函式
        /// </summary>
        /// <param name="obj">input的監聽事件資訊</param>
        void inputTickEvent(InputAction.CallbackContext obj)
        {
            TickInputEvent tickEvent = tickInputEventPool.newObject();
            tickEvent.setTickEvent(obj, gameTickTimer.getRunTick());
            tickInputEventsBuffer.Add(tickEvent);
        }

        /// <summary>
        /// 呼叫執行邏輯幀
        /// </summary>
        void runTicksLogic()
        {
            //運行此update發生前的所有邏輯幀
            ticksLogic.tryDoTicksBeforeTick(gameTickTimer.getRunTick());
            //強迫 or 嘗試，執行update前最後邏輯幀
            if (inputSelcetOption.forceTickBeforeUpdate)
            {
                ticksLogic.tryDoTicksBeforeTickForce(gameTickTimer.getRunTick());
            }
            else
            {
                ticksLogic.tryDoTicksBeforeTick(gameTickTimer.getRunTick());
            }
        }

        /// <summary>
        /// 將TickEvent放回物件池
        /// </summary>
        /// <param name="tickEvent"></param>
        void putTickEventBackToPool(TickInputEvent tickEvent)
        {
            tickInputEventPool.ReturnObject(tickEvent);
        }
    }
}
