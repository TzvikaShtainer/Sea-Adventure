using System.Collections.Generic;
using UnityEngine;

namespace BuilderPatterns
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T prefab;
        private readonly Queue<T> pool;

        public ObjectPool(T prefab, int initialSize = 10)
        {
            this.prefab = prefab;
            pool = new Queue<T>();

            // Pre-instantiate objects and add them to the pool
            for (int i = 0; i < initialSize; i++)
            {
                T newObj = Object.Instantiate(prefab);
                newObj.gameObject.SetActive(false);
                pool.Enqueue(newObj);
            }
        }

        public T GetFromPool()
        {
            if (pool.Count > 0)
            {
                T obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                // If pool is empty, instantiate a new one
                T newObj = Object.Instantiate(prefab);
                return newObj;
            }
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}