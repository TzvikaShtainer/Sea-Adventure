using System;
using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
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
        
        SoundManager.instance.PlayOneShot(FModEvents.instance.EnemyElectrified, transform.position);

        moveToPlayer.EnemyElectrified();
    }

    public void EnemyDeath()
    {
        Debug.Log("herer");
        if (enemyAnimationController == null)
            return;
        Debug.Log("here");
        enemyAnimationController.PlayDeathAnimation();
    }
}
