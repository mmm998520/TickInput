using UnityEngine.InputSystem;

namespace GameDevTools.TickEventSystem
{
    /// <summary>
    /// Tick輸入事件
    /// </summary>
    public class TickInputEvent
    {
        /// <summary>
        /// 輸入事件內容
        /// </summary>
        public InputAction.CallbackContext inputCallback;

        /// <summary>
        /// 輸入事件發生在第幾個Tick
        /// </summary>
        public long eventTriggerTick;

        /// <summary>
        /// 無參數建構子
        /// </summary>
        public TickInputEvent()
        {

        }

        /// <summary>
        /// 設定TickEvent數值
        /// </summary>
        /// <param name="_inputCallback">輸入事件內容</param>
        /// <param name="_eventTriggerTick">輸入事件發生在第幾個Tick</param>
        public void setTickEvent(InputAction.CallbackContext _inputCallback, long _eventTriggerTick)
        {
            inputCallback = _inputCallback;
            eventTriggerTick = _eventTriggerTick;
        }
    }
}