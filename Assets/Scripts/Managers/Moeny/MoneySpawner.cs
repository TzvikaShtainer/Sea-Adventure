using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float xPosToSpawn;
    [SerializeField] private float yPosToSpawn;
    [SerializeField] private GameObject coinPrefab;
    
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
            SpawnCoin();
            spawnTimer = 0;
        }
    }

    private void SpawnCoin()
    {
        yPosToSpawn = Random.Range(-4, 4);
        xPosToSpawn = Random.Range(9, 15);
        
        GameObject coinToSpawn = Instantiate(coinPrefab, new Vector2(xPosToSpawn, yPosToSpawn), Quaternion.identity);
    }
}
