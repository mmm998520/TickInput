using System;

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
        /// 遊戲開始時的時間
        /// </summary>
        static long gameStartTime = 0;

        /// <summary>
        /// 事件發生在第幾個Tick
        /// </summary>
        public int eventTriggerTick;
        /// <summary>
        /// 事件內容
        /// </summary>
        public string eventContent;

        /// <summary>
        /// 須於遊戲開始時偵測時間，以該時間為起始運算邏輯幀
        /// </summary>
        public static void setGameStartTime()
        {
            gameStartTime = DateTime.Now.Ticks;
        }
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
        /// <param name="_eventContent">事件內容</param>
        public void setTickEvent(int _eventTriggerTick, string _eventContent)
        {
            eventTriggerTick = _eventTriggerTick;
            eventContent = _eventContent;
        }

        /// <summary>
        /// 將當前時間轉換為遊戲開始後第幾個邏輯幀
        /// </summary>
        /// <returns></returns>
        public static int DataTimeToTick()
        {
            if (gameStartTime == 0)
            {
                setGameStartTime();
            }

            return (int)(DateTime.Now.Ticks - gameStartTime) / oneTickTime;
        }

        /// <summary>
        /// 將指定時間轉換為遊戲開始後第幾個邏輯幀
        /// </summary>
        /// <param name="DataTime">時間</param>
        /// <returns></returns>
        public static int DataTimeToTick(long DataTime)
        {
            if(gameStartTime == 0)
            {
                setGameStartTime();
            }

            return (int)(DataTime - gameStartTime) / oneTickTime;
        }

        /// <summary>
        /// <para>計算兩時間中經歷了幾個tick</para>
        /// <para>可藉由結果正負值得知時間先後</para>
        /// </summary>
        /// <param name="DataTimeA">先發生的時間</param>
        /// <param name="DataTimeB">後發生的時間</param>
        /// <returns></returns>
        public static int DataTimeIntervalToTick(long DataTimeA, long DataTimeB)
        {
            int t = DataTimeToTick(DataTimeB) - DataTimeToTick(DataTimeA);
            return t;
        }

        /// <summary>
        /// <para>計算兩時間中經歷了幾個tick</para>
        /// </summary>
        /// <param name="DataTimeA">時間A</param>
        /// <param name="DataTimeB">時間B</param>
        /// <returns></returns>
        public static int DataTimeIntervalToTickABS(long DataTimeA, long DataTimeB)
        {
            int t = DataTimeToTick(DataTimeA) - DataTimeToTick(DataTimeB);
            return Mathff.abs(t);
        }
    }
}