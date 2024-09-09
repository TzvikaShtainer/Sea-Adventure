using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float minSpawnDistance = 2f;
    [SerializeField] private float xPosToSpawn;
    
    private EnemyFactory enemyFactory;
    private float spawnTimer;

    private void Start()
    {
        enemyFactory = new EnemyFactory();
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
            SpawnEnemy();
            spawnTimer = 0;
        }
    }
    
    private void SpawnEnemy()
    {
        BaseEnemy enemy = GetRandomEnemyToSpawn();

        if (enemy == null)
            return;
        
        Vector2 spawnPosition = new Vector2(
            xPosToSpawn,
            Random.Range(enemy.GetMinYPosToSpawn(), enemy.GetMaxYPosToSpawn()));
        
        enemy.Spawn(spawnPosition);
    }
    
    private BaseEnemy GetRandomEnemyToSpawn()
    {
        EnemyType randomEnemyToSpawn = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length);
        BaseEnemy enemy = enemyFactory.CreateEnemy(randomEnemyToSpawn, Vector2.zero);
        return enemy;
    }
}
