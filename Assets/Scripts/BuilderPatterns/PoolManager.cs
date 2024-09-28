using System.Collections.Generic;
using UnityEngine;

namespace BuilderPatterns
{
    public enum ItemType
    {
        FishingRod,
        SwordFish,
        SeaUrchin,
        SeaMine,
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
        
        objectPools[ItemType.FishingRod] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/FishingRod"), 3);
        objectPools[ItemType.SwordFish] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/SwordFishWithUI"), 3);
        objectPools[ItemType.SeaUrchin] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/SeaUrchin"), 2);
        objectPools[ItemType.SeaMine] = new ObjectPool<Item>(Resources.Load<Item>("Enemies/SeaMine"), 2);
        objectPools[ItemType.AddLife] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/AddLifePowerUp"), 2);
        objectPools[ItemType.MaxSize] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/MaxiSizePowerUp"), 2);
        objectPools[ItemType.MinSize] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/MiniSizePowerUp"), 2);
        objectPools[ItemType.Shield] = new ObjectPool<Item>(Resources.Load<Item>("PowerUps/ShieldPowerUp"), 2);
        objectPools[ItemType.Coin] = new ObjectPool<Item>(Resources.Load<Item>("Others/Coin"), 3);
    }

    public Item GetItemFromPool(ItemType itemType)
    {
        if (objectPools.TryGetValue(itemType, out var pool))
        {
            return pool.GetFromPool();
        }
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