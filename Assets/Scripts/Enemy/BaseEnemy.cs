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
    [SerializeField] private EnemyAnimationController enemyAnimationController;
    [SerializeField] private MoveToPlayer moveToPlayer;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    
    
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
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
