using UnityEngine;
using LitJson;
using System.IO;

namespace GameDevTools.JsonToClass
{
    public class JsonToClass<T> where T : class, new()
    {
        public static T Converter(string JsonPath)
        {
            if (!File.Exists(JsonPath))
            {
                Debug.LogError("json資料轉換失效_應該是路徑無效");
                return null;
            }
            T t;
            using (var stream = new StreamReader(JsonPath))
            {
                var jsonStr = stream.ReadToEnd();
                t = JsonMapper.ToObject<T>(jsonStr);
            }
            return t;
        }
    }
}