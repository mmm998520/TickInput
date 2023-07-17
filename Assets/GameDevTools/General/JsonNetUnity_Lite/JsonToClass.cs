using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace GameDevTools.General.JsonToClass
{
    /// <summary>
    /// 將Json檔轉為class，使用JsonNet
    /// </summary>
    /// <typeparam name="T">需轉換的class的型別</typeparam>
    public class JsonToClass<T> where T : class, new()
    {
        /// <summary>
        /// 回傳轉換完畢的class，使用JsonNet
        /// </summary>
        /// <param name="path">json檔的路徑</param>
        public static T convert(string path)
        {
            string jsonString = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// 回傳轉換完畢的class，使用JsonNet
        /// </summary>
        /// <param name="path">json檔的TextAsset格式</param>
        public static T convert(TextAsset textAsset)
        {
            string jsonString = textAsset.text;
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
