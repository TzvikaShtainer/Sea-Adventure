using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public delegate void OnEnemyDead();
        public static event OnEnemyDead onEnemyDead;
        
        [SerializeField] private Vector2 minSpawnPosition;
        [SerializeField] private Vector2 maxSpawnPosition;

        [SerializeField] private BaseEnemy _baseEnemy;

        private void Awake()
        {
            _baseEnemy = GetComponent<BaseEnemy>();
            _baseEnemy.SetSpawnBoundaries(minSpawnPosition, maxSpawnPosition);
        }

        private void Update()
        {
            if (transform.position.x < -9.5) //just for now
            {
                gameObject.SetActive(false);
                
                onEnemyDead?.Invoke();

                EnemySpawner.Instance.RemoveInactiveEnemies(_baseEnemy.PositionToRemove);
            }
        }
    }
}