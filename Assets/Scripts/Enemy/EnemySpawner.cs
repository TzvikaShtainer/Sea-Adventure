using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float xPosToSpawn;
    private EnemyFactory enemyFactory;
    private float spawnTimer;

    private void Start()
    {
        enemyFactory = new EnemyFactory();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTime)
        {
            SpawnRandomEnemy();
            spawnTimer = 0;
        }
    }

    private void SpawnRandomEnemy() //need to make different places spawn for different enemies
    {
        EnemyType randomEnemyToSpawn = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length);
        
        float randomY = Random.Range(0.5f, 5.5f);
        
        spawnPosition = new Vector2(xPosToSpawn, randomY);
        
        enemyFactory.CreateEnemy(randomEnemyToSpawn, spawnPosition);
    }
}
