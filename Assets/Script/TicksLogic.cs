using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TickEventSystem
{
    public class TicksLogic
    {
        /// <summary>
        /// 當前運算中、以運算完畢的tick，-1代表尚未開始運算
        /// </summary>
        long currentTick = -1;
        /// <summary>
        /// 管控此邏輯幀的輸入管理員
        /// </summary>
        public InputEventManager inputEventManager;

        /// <summary>
        /// 執行邏輯幀邏輯
        /// </summary>
        public void doTick()
        {
            //Debug.Log("Tick : " + currentTick);
            InputStat.ButtonStat A_button = inputEventManager.inputStat.A_Button;
            if (A_button.isButtonPressing)
            {
                //Debug.LogWarning(A_button.isButtonPressing + "" + A_button.lastButtonDownTick);
            }
            else
            {
                //Debug.LogWarning(A_button.isButtonPressing + "" + A_button.lastButtonUpTick);
            }
        }

        /// <summary>
        /// 運算輸入發生前的所有邏輯幀，如有邏輯錯誤則回傳false告知
        /// </summary>
        /// <param name="inputTick">將發生輸入的時間，此幀不可參與運算</param>
        public bool tryTicksBeforeTick(long inputTick)
        {
            //防止有後來才被讀取的輸入進入，可能會有輸入在unityevent處理時被擋下，須注意
            bool haveError = true;
            if (inputTick <= currentTick)
            {
                Debug.LogError("時間邏輯錯誤，currentTick : " + currentTick + ", inputTick : " + inputTick);
                inputTick = currentTick +1;
                haveError = false;
            }
            //執行已確定無輸入變更的邏輯幀
            for(long i = currentTick+1; i < inputTick; i++)
            {
                currentTick++;
                doTick();
            }
            //如果發生錯誤，則回傳true告知
            return haveError;
        }

    }
}