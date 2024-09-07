using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float minSpawnDistance = 2f;
    //[SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float xPosToSpawn;
    
    private EnemyFactory enemyFactory;
    private float spawnTimer;
    
    [SerializeField] private List<Vector2> activeEnemyPositions = new List<Vector2>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
            SpawnEnemyWithValidation();
            spawnTimer = 0;
        }
    }

    private void SpawnEnemyWithValidation()
    {
        BaseEnemy enemy = GetRandomEnemyToSpawn();

        if (enemy == null)
            return;
        
        Vector2 spawnPosition = GetValidSpawnPosition(enemy.MinSpawnPosition, enemy.MaxSpawnPosition);
        Debug.Log(spawnPosition);
        
        if (spawnPosition != Vector2.zero)
        {
            enemy.Spawn(spawnPosition);
            activeEnemyPositions.Add(spawnPosition);
            
            enemy.SetPositionToRemove(spawnPosition); //just for now
        }
        else
        {
            Destroy(enemy.gameObject); // Destroy the enemy if no valid spawn position is found
        }
    }

    private BaseEnemy GetRandomEnemyToSpawn()
    {
        EnemyType randomEnemyToSpawn = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length);
        BaseEnemy enemy = enemyFactory.CreateEnemy(randomEnemyToSpawn, Vector2.zero);
        return enemy;
    }

    private Vector2 GetValidSpawnPosition(Vector2 enemyMinSpawnPosition, Vector2 enemyMaxSpawnPosition)
    {
        for (int attempt = 0; attempt < 10; attempt++)
        {
            Vector2 potentialPosition = new Vector2(
                Random.Range(enemyMinSpawnPosition.x, enemyMaxSpawnPosition.x),
                Random.Range(enemyMinSpawnPosition.y, enemyMaxSpawnPosition.y)
            );

            // Check if the position is far enough from the player and other enemies
            if (IsPositionValid(potentialPosition))
            {
                return potentialPosition;
            }
        }

        // Return Vector2.zero if no valid position is found
        return Vector2.zero;
    }

    private bool IsPositionValid(Vector2 potentialPosition)
    {
        foreach (Vector2 activePosition in activeEnemyPositions)
        {
            if (Vector2.Distance(potentialPosition, activePosition) < minSpawnDistance)
            {
                return false;
            }
        }

        return true;
    }
    
    public void RemoveInactiveEnemies(Vector2 position)
    {
        // Optionally clean up the list by removing positions of enemies that are no longer active
        activeEnemyPositions.RemoveAll(position => !EnemyAtPosition(position));
    }
    
    private bool EnemyAtPosition(Vector2 position)
    {
        
        return false;
    }
}
