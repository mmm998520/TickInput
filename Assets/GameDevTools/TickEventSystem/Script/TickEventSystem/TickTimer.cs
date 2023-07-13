using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using GameDevTools.General;

namespace GameDevTools.TickEventSystem
{
    /// <summary>
    /// 計時器，並計算邏輯幀
    /// </summary>
    public class TickTimer : MonoBehaviour
    {
        /// <summary>
        /// <para>定義每個Tick的間隔時間</para>
        /// <para>單位 : 毫秒   (1秒 = 1000毫秒)</para>
        /// </summary>
        int oneTickTime; 
        /// <summary>
        /// 高精度計時器，可記錄到毫秒(1/1000秒)級別
        /// </summary>
        Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// <para>無參數建構子</para>
        /// <para>建構時監聽UnityEditor暫停鍵是否被按下</para>
        /// </summary>
        public TickTimer()
        {
            EditorApplication.pauseStateChanged += unityEditorPauseState;

            //建構避免oneTickTime太小陷入故障無限迴圈
            if (oneTickTime < 1)
            {
                oneTickTime = 1;
            }
        }

        /// <summary>
        /// <para>建構子</para>
        /// <para>建構時監聽UnityEditor暫停鍵是否被按下</para>
        /// </summary>
        /// <param name="_oneTickTime">定義每個Tick的間隔時間，單位 : 毫秒   (1秒 = 1000毫秒)</param>
        public TickTimer(int _oneTickTime)
        {
            EditorApplication.pauseStateChanged += unityEditorPauseState;

            //建構避免oneTickTime太小陷入故障無限迴圈
            oneTickTime = _oneTickTime;
            if (oneTickTime < 1)
            {
                oneTickTime = 1;
            }
        }

        #region//計時器控制
        /// <summary>
        /// 開始執行計時器
        /// </summary>
        public void startStopwatch()
        {
            stopwatch.Start();
        }

        /// <summary>
        /// 停止執行計時器
        /// </summary>
        public void stopStopwatch()
        {
            stopwatch.Stop();
        }

        /// <summary>
        /// 歸零計時器
        /// </summary>
        public void resetStopwatch()
        {
            stopwatch.Reset();
        }

        /// <summary>
        /// 歸零並重啟執行計時器
        /// </summary>
        public void restartStopwatch()
        {
            stopwatch.Restart();
        }
        #endregion

        #region//獲取計時器時間
        /// <summary>
        /// 獲取當前時間
        /// </summary>
        /// <returns></returns>
        public long getRunTime()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// 獲取當前邏輯幀
        /// </summary>
        /// <returns></returns>
        public long getRunTick()
        {
            return timeToTick(stopwatch.ElapsedMilliseconds);
        }
        #endregion

        #region//計時器計算
        /// <summary>
        /// 將指定時間轉換為計時器開始後第幾個邏輯幀
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public long timeToTick(long time)
        {
            return time / oneTickTime;
        }

        /// <summary>
        /// <para>計算兩時間中經歷了幾個tick</para>
        /// <para>可藉由結果正負值得知時間先後</para>
        /// </summary>
        /// <param name="timeA">先發生的時間</param>
        /// <param name="timeB">後發生的時間</param>
        /// <returns></returns>
        public long intervalTimeToTick(long timeA, long timeB)
        {
            long t = timeToTick(timeB) - timeToTick(timeA);
            return t;
        }

        /// <summary>
        /// <para>計算兩時間中經歷了幾個tick</para>
        /// <para>無視時間先後順序</para>
        /// </summary>
        /// <param name="timeA">時間A</param>
        /// <param name="timeB">時間B</param>
        /// <returns></returns>
        public long intervalTimeToTickAbs(long timeA, long timeB)
        {
            long t = timeToTick(timeB) - timeToTick(timeA);
            return Mathff.abs(t);
        }
        #endregion

        #region//暫停遊戲就暫停計時器
        /// <summary>
        /// 當UnityEditer暫停就暫停遊戲
        /// </summary>
        /// <param name="pauseStatus">UnityEditer是否暫停</param>
        /// 
        void unityEditorPauseState(PauseState state)
        {

            if (state == PauseState.Paused)
            {
                UnityEngine.Debug.LogError("pause");
                stopStopwatch();
            }
            else
            {
                UnityEngine.Debug.LogError("start");
                startStopwatch();
            }
        }
        #endregion
    }
}