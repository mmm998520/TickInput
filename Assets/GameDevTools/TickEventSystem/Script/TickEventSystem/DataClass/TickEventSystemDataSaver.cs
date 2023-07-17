using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTools.General.JsonToClass;

namespace GameDevTools.TickEventSystem
{
    public class TickEventSystemDataSaver : MonoBehaviour
    {
        /// <summary>
        /// InputCMD存檔內容
        /// </summary>
        [HideInInspector] public static Dictionary<string, InputCMD> InputCMDList;

        [Header("存檔路徑")]
        [Tooltip("InputCMD的json檔是否在Resources資料夾下")]
        public bool isInputCMDInResources;
        [Tooltip("InputCMD的json檔的存檔位置\n" +
                        "如果在Resources下則從免填Resources本身")]
        public string inputCMDPath;

        void Start()
        {
            InputCMDloadData(isInputCMDInResources, inputCMDPath);
        }

        /// <summary>
        /// 根據路經獲取InputCMD的json檔，並存入dictionary中
        /// </summary>
        /// <param name="isInResources">json檔是否在Resources資料夾下</param>
        /// <param name="path">json檔的存檔位置</param>
        void InputCMDloadData(bool isInResources, string path)
        {
            if (isInResources)
            {
                TextAsset textAsset = Resources.Load<TextAsset>(path);
                InputCMDList = JsonToClass<Dictionary<string, InputCMD>>.convert(textAsset);
            }
            else
            {
                InputCMDList = JsonToClass<Dictionary<string, InputCMD>>.convert(inputCMDPath);
            }
        }
    }
}