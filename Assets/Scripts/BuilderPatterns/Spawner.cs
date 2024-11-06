using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float xPosToSpawn;
    [SerializeField] public bool canSpawn = false;
    [SerializeField] private ItemType itemType;
    
    [Header("PreSpawn Settings")]
    [SerializeField] private float spawnOnlyAfterTime;
    [SerializeField] public bool nowSpawnedYet = false;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (!canSpawn && !nowSpawnedYet) 
        {
            if (spawnTimer > spawnOnlyAfterTime)
            {
                canSpawn = true;
                nowSpawnedYet = true;
            }
        }

        if (canSpawn)
        {
            HandleSpawn();
        }
    }

    private void HandleSpawn()
    {
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
