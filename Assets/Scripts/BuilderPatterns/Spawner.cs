using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float xPosToSpawn;
    //[SerializeField] private float yPosToSpawn;
    [SerializeField] private ItemType itemType;
    
    private Factory factroy;
    private float spawnTimer;

    private void Start()
    {
        factroy = new Factory();
    }

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
        Item item = factroy.CreateItem(itemType, Vector2.zero);
        
        if (item == null)
            return;
        
        Vector2 spawnPosition = new Vector2(
            xPosToSpawn,
            Random.Range(item.GetMinYPosToSpawn(), item.GetMaxYPosToSpawn()));
        
        item.Spawn(spawnPosition);
    }
}
