using System.Collections.Generic;
using UnityEngine;

namespace BuilderPatterns
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T prefab;
        private readonly List<T> pool;

        public ObjectPool(T prefab, int initialSize = 10)
        {
            this.prefab = prefab;
            pool = new List<T>();

            // Pre-instantiate objects and add them to the pool
            for (int i = 0; i < initialSize; i++)
            {
                T newObj = Object.Instantiate(prefab);
                newObj.gameObject.SetActive(false);
                pool.Add(newObj);
            }
        }

        public T GetFromPool()
        {
            foreach (T obj in pool)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    //Debug.Log($"Reusing object from pool: {obj.name}");
                    return obj;
                }
            }
            
            T newObj = Object.Instantiate(prefab);
            newObj.gameObject.SetActive(true);
            pool.Add(newObj);
            //Debug.Log($"Instantiated new object: {newObj.name}");
            return newObj;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}