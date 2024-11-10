using System.Collections.Generic;
using UnityEngine;

namespace BuilderPatterns
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T prefab;
        private readonly List<T> pool;
        private readonly Transform parentTransform;

        public ObjectPool(T prefab, int initialSize = 10, Transform parentTransform = null)
        {
            this.prefab = prefab;
            this.parentTransform = parentTransform;  // Assign the parent transform
            pool = new List<T>();

            // Pre-instantiate objects and add them to the pool
            for (int i = 0; i < initialSize; i++)
            {
                T newObj = Object.Instantiate(prefab, parentTransform);  // Set parent on instantiation
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
                    return obj;
                }
            }
            
            T newObj = Object.Instantiate(prefab, parentTransform);  // Set parent on new instantiation
            newObj.gameObject.SetActive(true);
            pool.Add(newObj);
            return newObj;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}