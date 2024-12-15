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

    private void OnEnable()
    {
        ChangeCollidersArrayState(true);
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

        ChangeCollidersArrayState(false);

        enemyAnimationController.PlayElectrifiedAnimation();
        
        SoundManager.Instance.PlayOneShot(FModEvents.Instance.EnemyElectrified, transform.position);

        if (moveToPlayer.GetItemType() == ItemType.FishingRod || moveToPlayer.GetItemType() == ItemType.SeaMine )
        {
            MakeSound();
        }
        else
        {
            moveToPlayer.EnemyElectrified();
        }
    }

    private void ChangeCollidersArrayState(bool newState)
    {
        for (int i = 0; i < enemyCollidersArray.Length; i++)
        {
            enemyCollidersArray[i].enabled = newState;
        }
    }
    
    public void EnemyDeath()
    {
        if (enemyAnimationController == null)
            return;

        enemyAnimationController.PlayDeathAnimation();
    }

    public void MakeSound()
    {
        if (moveToPlayer.GetItemType() == ItemType.FishingRod)
        {
            SoundManager.Instance.PlayOneShot(FModEvents.Instance.FisherNetHit, transform.position);
        }
        else if (moveToPlayer.GetItemType() == ItemType.SeaMine)
        {
            SoundManager.Instance.PlayOneShot(FModEvents.Instance.BombHit, transform.position);
        }
    }
}
