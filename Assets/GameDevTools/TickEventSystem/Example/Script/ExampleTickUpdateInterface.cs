using System.Collections.Generic;

namespace GameDevTools.TickEventSystem
{
    #region//關於觀察者模式的範例，主題(TickUpdateSubject範例)已於TicksLogic中時做，需使用TickUpdate只需訂閱即可

    /// <summary>
    /// TickUpdateSubject範例
    /// </summary>
    public class ExampleSubject : TickUpdateSubject
    {
        /// <summary>
        /// TickUpdateObserver觀察者清單
        /// </summary>
        private List<TickUpdateObserver> observers = new List<TickUpdateObserver>();

        /// <summary>
        /// 將TickUpdateObserver加入觀察者清單
        /// </summary>
        /// <param name="observer">TickUpdateObserver觀察者</param>
        public void AddObserver(TickUpdateObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 將TickUpdateObserver移除觀察者清單
        /// </summary>
        /// <param name="observer">TickUpdateObserver觀察者</param>
        public void RemoveObserver(TickUpdateObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// 通知所有TickUpdateObserver觀察者執行TickUpdate
        /// </summary>
        public void NotifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].TickUpdate();
            }
        }
    }

    /// <summary>
    /// TickUpdateObserver範例
    /// </summary>
    public class ExampleObserver : TickUpdateObserver
    {
        public void TickUpdate()
        {
            //執行邏輯
        }
    }

    /// <summary>
    /// 實際執行範例範例
    /// </summary>
    public class ExampleMain
    {
        public void main()
        {
            //建立主體
            ExampleSubject subject = new ExampleSubject();
            //建立觀察者，此步驟之後會移至觀察者中
            TickUpdateObserver observer1 = new ExampleObserver();
            TickUpdateObserver observer2 = new ExampleObserver();
            //將觀察者加入觀察者清單，此步驟之後會移至觀察者中
            subject.AddObserver(observer1);
            subject.AddObserver(observer2);
            //通知所有觀察者執行TickUpdate
            subject.NotifyObservers();
        }
    }

    #endregion
}