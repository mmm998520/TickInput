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
        [HideInInspector] public Queue<TickEvent> tickEvents = new Queue<TickEvent>();
        /// <summary>
        /// 輸入事件物件池
        /// </summary>
        [HideInInspector] public ObjPool<TickEvent> tickEventPool = new ObjPool<TickEvent>(30);
        /// <summary>
        /// 當前邏輯幀的輸入狀態
        /// </summary>
        [HideInInspector] public InputState inputState = new InputState();
        /// <summary>
        /// 邏輯幀運算器
        /// </summary>
        [HideInInspector] public TicksLogic ticksLogic;

        #region//inspector面板可控
        #region//bool forceTickBeforeUpdate 是否強制執行update前的最後邏輯幀
        [Header("是否強制執行update前的最後邏輯幀")]
        [Tooltip(
            "不建議 ture !!!\n\n" +
            "當邏輯幀與Update時間重疊時，是否強迫等邏輯幀運算完畢才執行Update\n\n" +
            "ture : 輸入判定與畫面較同步，但輸入較糊，部分輸入會被延遲判定，適合體驗、回合制遊戲\n\n" +
            "false : 輸入判定會慢於畫面更新，但輸入較穩定，適合格鬥遊戲"
            )]
        public bool forceTickBeforeUpdate;
        #endregion
        #region//int oneTickTime tick單位時長
        [Header("tick單位時長")]
        [Tooltip(
            "定義每個Tick的間隔時間\n" +
            "單位 : 毫秒   (1秒 = 1000毫秒)\n" +
            "最小值為1"
            )]
        [Range(1,9999)]
        public int oneTickTime = 10;
        #endregion
        #endregion

        private void Awake()
        {
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
        /// 確保有計時器，並開始計時
        /// </summary>
        void restartGameTickTimer()
        {
            if (gameTickTimer == null)
            {
                gameTickTimer = new TickTimer(oneTickTime);
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
            TickEvent tickEvent = tickEventPool.newObject();
            tickEvent.setTickEvent(gameTickTimer.getRunTick(), obj.control.name, obj.phase.ToString());
            tickEvents.Enqueue(tickEvent);
        }

        /// <summary>
        /// 呼叫執行邏輯幀
        /// </summary>
        void runTicksLogic()
        {
            //運行此update發生前的所有邏輯幀
            for (int i = 0; i < tickEvents.Count; i++)
            {
                //從事件紀錄中抽取資料
                TickEvent tickEvent = tickEvents.Dequeue();
                //嘗試執行邏輯幀，只會運算事件紀錄發生前的邏輯幀，當出現問題時回報
                bool isLogicTickError = !ticksLogic.tryTicksBeforeTick(tickEvent.eventTriggerTick);
                //若邏輯幀沒問題則紀錄輸入
                if (!isLogicTickError)
                {
                    inputState.switchByInputContent(tickEvent.eventTriggerTick, tickEvent.eventBelong, tickEvent.eventContent);
                }
                //將用畢的事件紀錄返回物件池
                putTickEventBackToPool(tickEvent);
            }
            //強迫 or 嘗試，執行update前最後邏輯幀
            if (forceTickBeforeUpdate)
            {
                ticksLogic.tryTicksBeforeTickForce(gameTickTimer.getRunTick());
            }
            else
            {
                ticksLogic.tryTicksBeforeTick(gameTickTimer.getRunTick());
            }
        }

        /// <summary>
        /// 將TickEvent放回物件池
        /// </summary>
        /// <param name="tickEvent"></param>
        void putTickEventBackToPool(TickEvent tickEvent)
        {
            tickEvent.resetTickEvent();
            tickEventPool.ReturnObject(tickEvent);
        }
    }

    /// <summary>
    /// 紀錄當前邏輯幀輸入狀態
    /// </summary>
    public class InputState
    {
        /// <summary>
        /// 紀錄按鈕狀態與時長
        /// </summary>
        public class ButtonState
        {
            /// <summary>
            /// 按鈕是否被按下
            /// </summary>
            public bool isButtonPressing = false;
            /// <summary>
            /// 上次按鈕被按下的tick，-1代表沒被按下過
            /// </summary>
            public long lastButtonDownTick = -1;
            /// <summary>
            /// 上次按鈕被放開的tick，-1代表沒被放開過
            /// </summary>
            public long lastButtonUpTick = -1;

            /// <summary>
            /// 定義按鈕的四種狀態，但會有後兩種，甚至一幀內按下放開按下的操作
            /// </summary>
            public enum ButtonStateEnum
            {
                None,//沒按
                Down,//按下瞬間
                Hold,//按著
                Up,//放開瞬間
                QuickClick,//一幀內按下、放開
                QuickRelease//一幀內放開、按下
            }

            public ButtonStateEnum getButtonStateEnum(long currentTick)
            {

                if (lastButtonDownTick > lastButtonUpTick)
                {
                    if (currentTick == lastButtonDownTick)
                    {
                        return ButtonStateEnum.Down;
                    }
                    else
                    {
                        return ButtonStateEnum.Hold;
                    }
                }
                else if (lastButtonDownTick == lastButtonUpTick)
                {
                    if (lastButtonDownTick < 0)
                    {
                        return ButtonStateEnum.None;
                    }
                    else
                    {
                        return ButtonStateEnum.QuickClick;
                    }
                }
                else
                {
                    if (currentTick == lastButtonUpTick)
                    {
                        return ButtonStateEnum.Up;
                    }
                    else
                    {
                        return ButtonStateEnum.None;
                    }
                }
            }
        }

        /// <summary>
        /// 建構初始的ButtonStat
        /// </summary>
        public ButtonState A_Button = new ButtonState();

        /// <summary>
        /// 根據輸入內容與時間設置輸入狀態
        /// </summary>
        /// <param name="InputContent"></param>
        public void switchByInputContent(long eventTriggerTick, string eventBelong, string eventContent)
        {
            //根據名字判定執行內容
            switch (eventBelong)
            {
                case "a":
                    if (eventContent == "Started")
                    {
                        A_Button.isButtonPressing = true;
                        A_Button.lastButtonDownTick = eventTriggerTick;
                    }
                    else if (eventContent == "Canceled")
                    {
                        A_Button.isButtonPressing = false;
                        A_Button.lastButtonUpTick = eventTriggerTick;
                    }
                    break;
                default:
                    Debug.LogError("這裡不該有內容");
                    break;
            }
        }
    }
}
