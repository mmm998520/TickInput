using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace GameDevTools.General.JsonToClass.Example
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<Item> Inventory { get; set; }
        public string[] Sts { get; set; }
    }

    public class Item
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }

    public class JsonToClassExample : MonoBehaviour
    {
        public void Start()
        {
            string jsonString = "{ 'Name': 'John', 'Level': 1, 'Inventory': [ { 'ItemName': 'Apple', 'Quantity': 5 }, { 'ItemName': 'Banana', 'Quantity': 2 } ], 'Sts':['a','b']}";

            Player player = JsonConvert.DeserializeObject<Player>(jsonString);

            Debug.Log(player.Name);  // Output: John
            Debug.Log(player.Inventory[0].ItemName);  // Output: Apple
            Debug.Log(player.Sts.Length);  // Output: 2
        }
    }
}