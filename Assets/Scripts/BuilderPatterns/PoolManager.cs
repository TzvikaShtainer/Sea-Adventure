﻿using System.Collections.Generic;
using UnityEngine;

namespace BuilderPatterns
{
    public enum ItemType
    {
        FishingRod,
        SwordFish,
        SeaUrchin,
        SeaMine,
        PufferFish,
        AddLife,
        MaxSize,
        MinSize,
        Shield,
        Coin
    }

    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance { get; private set; }

        private Dictionary<ItemType, ObjectPool<Item>> objectPools;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializePools();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializePools()
        {
            objectPools = new Dictionary<ItemType, ObjectPool<Item>>();

            // Initialize pools with the PoolManager's transform as the parent
            objectPools[ItemType.FishingRod] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/FishingRod"), 3, transform);
            objectPools[ItemType.SwordFish] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/SwordFishWithUI"), 20, transform);
            objectPools[ItemType.SeaUrchin] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/SeaUrchin"), 2, transform);
            objectPools[ItemType.SeaMine] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/SeaMine"), 2, transform);
            objectPools[ItemType.PufferFish] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/pufferFish"), 2, transform);

            objectPools[ItemType.AddLife] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/AddLifePowerUp"), 2, transform);
            objectPools[ItemType.MaxSize] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/MaxiSizePowerUp"), 2, transform);
            objectPools[ItemType.MinSize] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/MiniSizePowerUp"), 2, transform);

            objectPools[ItemType.Shield] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/ShieldPowerUp"), 2, transform);
            objectPools[ItemType.Coin] = new ObjectPool<Item>(Resources.Load<Item>("Others/Coin"), 3, transform);
        }

        public Item GetItemFromPool(ItemType itemType)
        {
            if (objectPools.TryGetValue(itemType, out var pool))
            {
                Item item = pool.GetFromPool();
                if (item != null)
                {
                    BaseEnemy baseEnemy = item.GetComponent<BaseEnemy>();
                    if (baseEnemy != null)
                    {
                        baseEnemy.enabled = true;
                    }

                    //Debug.Log($"Activated item from pool: {item.name}");
                    return item;
                }
            }
            //Debug.LogWarning($"Item of type {itemType} not found in pool!");
            return null;
        }
        
        public void ReturnItemToPool(ItemType itemType, Item item)
        {
            
            if (objectPools.TryGetValue(itemType, out var pool))
            {
                pool.ReturnToPool(item);
            }
        }
    }
}