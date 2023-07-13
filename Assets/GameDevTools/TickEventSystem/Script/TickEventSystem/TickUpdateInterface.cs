

namespace GameDevTools.TickEventSystem
{
    /// <summary>
    /// TickUpdate的觀察者，class繼承他後可觀察一個具有TickUpdateSubject的物件
    /// </summary>
    public interface TickUpdateObserver
    {
        /// <summary>
        /// 遊戲邏輯幀，須處理的邏輯事件都寫在這裡面
        /// </summary>
        void TickUpdate();
    }

    /// <summary>
    /// TickUpdate的主題，class繼承他後，可以發出NotifyObservers通知觀察者執行TickUpdate
    /// </summary>
    public interface TickUpdateSubject
    {
        /// <summary>
        /// 將觀察者加入觀察者清單
        /// </summary>
        /// <param name="observer">TickUpdate觀察者</param>
        void AddObserver(TickUpdateObserver observer);
        /// <summary>
        /// 將觀察者移除觀察者清單
        /// </summary>
        /// <param name="observer">TickUpdate觀察者</param>
        void RemoveObserver(TickUpdateObserver observer);
        /// <summary>
        /// 通知觀察者執行TickUpdate
        /// </summary>
        void NotifyObservers();
    }

    
}