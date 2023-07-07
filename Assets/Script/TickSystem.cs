using System;

namespace TickSystem
{
    public class TickEvent
    {
        static int oneTickTime = 100000;//單位 : 100毫微秒   (毫微秒為10的-9次方秒)
        static long gameStartTime = 0;

        public int eventTriggerTick;
        public string eventContent;

        public TickEvent(int _eventTriggerTick, string _eventContent)
        {
            eventTriggerTick = _eventTriggerTick;
            eventContent = _eventContent;
        }

        public static void setGameStartTime()
        {
            gameStartTime = DateTime.Now.Ticks;
        }

        public static int DataTimeToTick()
        {
            if (gameStartTime == 0)
            {
                setGameStartTime();
            }

            return (int)(DateTime.Now.Ticks - gameStartTime) / oneTickTime;
        }

        public static int DataTimeToTick(long DataTime)
        {
            if(gameStartTime == 0)
            {
                setGameStartTime();
            }

            return (int)(DataTime - gameStartTime) / oneTickTime;
        }
    }
}