using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float xPosToSpawn;
    [SerializeField] private EnemyType enemyType;
    
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
        BaseEnemy enemy = enemyFactory.CreateEnemy(enemyType, Vector2.zero);
        
        if (enemy == null)
            return;
        
        Vector2 spawnPosition = new Vector2(
            xPosToSpawn,
            Random.Range(enemy.GetMinYPosToSpawn(), enemy.GetMaxYPosToSpawn()));
        
        enemy.Spawn(spawnPosition);
    }
}
