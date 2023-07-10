using System.Collections;
using System.Collections.Generic;

namespace GameDevTools.General
{
    /// <summary>
    /// 通用物件池，實例化後可管理所有類型的class
    /// </summary>
    /// <typeparam name="T">必須為Class，且必需有new T()無參數建構子</typeparam>
    public class ObjPool<T> where T : class, new()
    {
        public Stack<T> pool = new Stack<T>();

        /// <summary>
        /// 物件池實例化建構式
        /// </summary>
        public ObjPool()
        {

        }

        /// <summary>
        /// 物件池實例化建構式
        /// </summary>
        /// <param name="initialSize">建構後預先創建多少物件於物件池中</param>
        public ObjPool(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                pool.Push(new T());
            }
        }

        /// <summary>
        /// 從物件池中抽取物件，若物件池數量不足，創造新物件
        /// </summary>
        /// <returns></returns>
        public T newObject()
        {
            if (pool.Count > 0)
            {
                return pool.Pop();
            }
            else
            {
                return new T();
            }
        }

        /// <summary>
        /// 將用完的物件返回至物件池中
        /// </summary>
        /// <param name="obj"></param>
        public void ReturnObject(T obj)
        {
            pool.Push(obj);
        }
    }
}