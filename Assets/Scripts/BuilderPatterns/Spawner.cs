using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float xPosToSpawn;
    [SerializeField] private BuilderPatterns.ItemType itemType;

    private float spawnTimer;

    private void Update()
    {
        HandleSpawn();
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
        
        Vector2 spawnPosition = new Vector2(
            xPosToSpawn,
            Random.Range(item.GetMinYPosToSpawn(), item.GetMaxYPosToSpawn()));
        
        item.Spawn(spawnPosition);
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}
