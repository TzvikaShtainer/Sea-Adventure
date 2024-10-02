using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float xPosToSpawn;
    [SerializeField] private ItemType itemType;
    
    [SerializeField] public bool canSpawn = true;

    private float spawnTimer;

    private void Update()
    {
        if (canSpawn)
        {
            HandleSpawn();
        }
    }

    private void HandleSpawn()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTime)
        {
            SpawnItem();
            spawnTimer = 0;
        }
    }

    private void SpawnItem()
    {
        Item item = PoolManager.Instance.GetItemFromPool(itemType);

        if (item == null)
            return;

        Vector2 spawnPosition;
            
        if (itemType == ItemType.SwordFish)
        {
            spawnPosition = new Vector2(
                0,
                Random.Range(item.GetMinYPosToSpawn(), item.GetMaxYPosToSpawn()));
        }
        else
        {
            spawnPosition = new Vector2(
                xPosToSpawn,
                Random.Range(item.GetMinYPosToSpawn(), item.GetMaxYPosToSpawn()));
        }
        
        item.Spawn(spawnPosition);
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public float GetSpawner()
    {
        return spawnTime;
    }

    public void SetSpawnTime(float newSpawnTime)
    {
        spawnTime = newSpawnTime;
    }

    public void SetCanSpawn(bool newCanSpawn)
    {
        canSpawn = newCanSpawn;
    }
}
