using System;
using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
using Enemy;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ISpawn
{
    [SerializeField] private PlayerController player;
    [SerializeField] private EnemyAnimationController enemyAnimationController;
    [SerializeField] private MoveToPlayer moveToPlayer;
    [SerializeField] private Collider2D[] enemyCollidersArray;
    

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        enemyCollidersArray = GetComponents<Collider2D>();
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

        for (int i = 0; i < enemyCollidersArray.Length; i++)
        {
            enemyCollidersArray[i].enabled = false;
        }

        enemyAnimationController.PlayElectrifiedAnimation();
        
        SoundManager.Instance.PlayOneShot(FModEvents.Instance.EnemyElectrified, transform.position);

        moveToPlayer.EnemyElectrified();
    }

    public void EnemyDeath()
    {
        if (enemyAnimationController == null)
            return;

        enemyAnimationController.PlayDeathAnimation();
    }
}
