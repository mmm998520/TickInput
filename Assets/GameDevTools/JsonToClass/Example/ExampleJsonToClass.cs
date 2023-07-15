using UnityEngine;

namespace GameDevTools.JsonToClass.Example
{
    public class ExampleJsonToClass : MonoBehaviour
    {
        string ExampleDataPath = "Assets/GameDevTools/JsonToClass/Example/ExampleData.json";

        void Start()
        {
            ExampleData exampleData = toClass();
            showData(exampleData);
        }

        /// <summary>
        /// 讀取json檔內容填入Data並回傳
        /// </summary>
        ExampleData toClass()
        {
            return JsonToClass<ExampleData>.Converter(ExampleDataPath);
        }

        /// <summary>
        /// 顯示讀取結果
        /// </summary>
        /// <param name="exampleData">讀取的資料內容</param>
        void showData(ExampleData exampleData)
        {
            print(exampleData.num1);
            print(exampleData.num2);
            print(exampleData.v2);
            print(exampleData.v3);
            print(exampleData.quaternion);
            print(exampleData.color1);
            print(exampleData.color2);
            print(exampleData.bounds);
            print(exampleData.rect);
            print(exampleData.animationCurve);
            print(exampleData.SerializeField);
        }
    }

    /// <summary>
    /// 示例用的資料類型
    /// </summary>
    public class ExampleData
    {
        public int num1;

        public float num2;

        public Vector2 v2;

        public Vector3 v3;

        public Quaternion quaternion;

        public Color color1;

        public Color32 color2;

        public Bounds bounds;

        public Rect rect;

        public AnimationCurve animationCurve;

        [LitJson.Extensions.JsonIgnore]
        public string SerializeField;
    }
}