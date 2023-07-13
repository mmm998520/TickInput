using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevTools.TickEventSystem
{
    /// <summary>
    /// 將輸入可選選項改為腳本化物件
    /// </summary>
    [CreateAssetMenu(fileName = "inputSelcetOption", menuName = "GameDevTools/TickEventSystem/inputSelcetOption", order = 1)]
    public class InputSelcetOption : ScriptableObject
    {
        #region//bool forceTickBeforeUpdate 是否強制執行update前的最後邏輯幀
        [Header("是否強制執行update前的最後邏輯幀")]
        [Tooltip(
                "不建議 ture !!!\n\n" +
                "當邏輯幀與Update時間重疊時，是否強迫等邏輯幀運算完畢才執行Update\n\n" +
                "ture : 輸入判定與畫面較同步，但輸入較糊，部分輸入會被延遲判定，適合體驗、回合制遊戲\n\n" +
                "false : 輸入判定會慢於畫面更新，但輸入較穩定，適合格鬥遊戲"
                )]
        public bool forceTickBeforeUpdate = false;
        #endregion
        #region//int oneTickTime tick單位時長
        [Header("tick單位時長")]
        [Tooltip(
            "定義每個Tick的間隔時間\n" +
            "單位 : 毫秒   (1秒 = 1000毫秒)\n" +
            "最小值為1"
            )]
        [Range(1, 9999)]
        public int oneTickTime = 17;
        #endregion


        /// <summary>
        /// 無參數建構子
        /// </summary>
        public InputSelcetOption()
        {
            forceTickBeforeUpdate = false;
            oneTickTime = 17;
        }
    }
}



