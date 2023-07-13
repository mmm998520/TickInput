using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevTools.TickEventSystem
{
    public class ExamplePlayerManager : MonoBehaviour, TickUpdateObserver
    {
        /// <summary>
        /// 此物件判定輸入接收的來源
        /// </summary>
        public InputEventManager inputEventManager;

        /// <summary>
        /// 最多讀取幾幀的操作(包含此幀，所以最小值為1)，超過此域值的操作將被銷毀(送回物件池)
        /// </summary>
        public int bufferTickMax = 5;

        void Start()
        {
            //遊戲開始時，將此程式作為觀察者，觀察主體(ticksLogic)，等待主體告知邏輯幀執行
            startAddObserver();
        }

        /// <summary>
        /// 遊戲開始時，將此程式作為觀察者，觀察主體(ticksLogic)，等待主體告知邏輯幀執行
        /// </summary>
        void startAddObserver()
        {
            if (inputEventManager == null)
            {
                Debug.LogError("inputEventManager來源缺失，無法運行");
            }
            inputEventManager.ticksLogic.AddObserver(this);
        }

        /// <summary>
        /// 執行邏輯幀操作，由TicksLogic的doTick()呼叫
        /// </summary>
        public void TickUpdate()
        {
            List<TickInputEvent> tickInputEventsBuffer = inputEventManager.tickInputEventsBuffer;
            int bufferCount = tickInputEventsBuffer.Count;
            for (int i = 0; i < bufferCount; i++)
            {
                //如果該輸入已超過輸入緩存區則將該輸入刪除
                if(tickInputEventsBuffer[i].eventTriggerTick + bufferTickMax < inputEventManager.ticksLogic.currentTick)
                {
                    TickInputEvent tickInputEvent = tickInputEventsBuffer[i];
                    tickInputEventsBuffer.RemoveAt(i);
                    bufferCount--;
                    inputEventManager.tickInputEventPool.ReturnObject(tickInputEvent);
                    continue;
                }
            }
        }
    }
}