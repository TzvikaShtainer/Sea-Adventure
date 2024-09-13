using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerUps
{
    public class PowerUpSpawner :MonoBehaviour
    {
        [SerializeField] private float spawnTime = 2f;
        [SerializeField] private float xPosToSpawn;
    
        private PowerUpFactory powerUpFactory;
        private float spawnTimer;

        private void Start()
        {
            powerUpFactory = new PowerUpFactory();
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
                SpawnPowerUp();
                spawnTimer = 0;
            }
        }
    
        private void SpawnPowerUp()
        {
            int randomPowerUpIndex = Random.Range(0, Enum.GetValues(typeof(PowerUpType)).Length);

            Array powerUpArray = Enum.GetValues(typeof(PowerUpType));
            
            BasePowerUp powerUp = powerUpFactory.CreatePowerUp((PowerUpType)powerUpArray.GetValue(randomPowerUpIndex), Vector2.zero);
        
            if (powerUp == null)
                return;
        
            Vector2 spawnPosition = new Vector2(
                xPosToSpawn,
                Random.Range(-3, 3));
        
            powerUp.Spawn(spawnPosition);
        }
    }
}