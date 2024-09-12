using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ISpawn
{
    public delegate void OnEnemyDead();
    public static event OnEnemyDead onEnemyDead;
    
    [SerializeField] private PlayerController player;
    [SerializeField] private float minYPosToSpawn;
    [SerializeField] private float maxYPosToSpawn;
    
    [SerializeField] private EnemyAnimationController enemyAnimationController;
    [SerializeField] private MoveToPlayer moveToPlayer;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (transform.position.x < -9.5 || transform.position.y < -5) //just for now
        {
            gameObject.SetActive(false);
                
            onEnemyDead?.Invoke();
        }
    }
    
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public float GetMinYPosToSpawn()
    {
        return minYPosToSpawn; 
    }
    
    public float GetMaxYPosToSpawn()
    {
        return maxYPosToSpawn; 
    }

    public PlayerController GetPlayer()
    {
        return player;
    }

    public void Electrified()
    {
        
        if (enemyAnimationController == null)
            return;

        enemyAnimationController.PlayElectrifiedAnimation();

        moveToPlayer.EnemyElectrified();
    }
}
