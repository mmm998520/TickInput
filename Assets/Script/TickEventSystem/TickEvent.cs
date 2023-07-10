using System;
using UnityEngine.InputSystem;

namespace TickEventSystem
{
    /// <summary>
    /// Tick事件
    /// </summary>
    public class TickEvent
    {
        /// <summary>
        /// <para>定義每個Tick的間隔時間</para>
        /// <para>單位 : 100毫微秒   (毫微秒為10的-9次方秒)</para>
        /// </summary>
        static int oneTickTime = 100000;

        /// <summary>
        /// 事件發生在第幾個Tick
        /// </summary>
        public long eventTriggerTick;
        /// <summary>
        /// 事件所屬，是哪個物件觸發的事件
        /// </summary>
        public string eventBelong;
        /// <summary>
        /// 事件內容
        /// </summary>
        public string eventContent;

        /// <summary>
        /// 無參數建構子
        /// </summary>
        public TickEvent()
        {
            resetTickEvent();
        }

        /// <summary>
        /// 將事件還原至初始狀態
        /// </summary>
        public void resetTickEvent()
        {
            eventTriggerTick = 0;
            eventContent = "";
        }

        /// <summary>
        /// 設定TickEvent數值
        /// </summary>
        /// <param name="_eventTriggerTick">事件發生在第幾個Tick</param>
        /// <param name="_eventBelong">事件內容</param>
        public void setTickEvent(long _eventTriggerTick, string _eventBelong, string _eventContent)
        {
            eventTriggerTick = _eventTriggerTick;
            eventBelong = _eventBelong;
            eventContent = _eventContent;
        }
    }
}