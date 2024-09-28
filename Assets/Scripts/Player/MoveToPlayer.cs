using System;
using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidBody;
    [SerializeField] private float leftSpeed;
    [SerializeField] private ItemType itemType;
    
    private bool isElectrified;
    

    private void OnEnable()
    {
        isElectrified = false;
    }

    private void Update()
    {
        if (!isElectrified)
        {
            if (itemType == ItemType.FishingRod || itemType == ItemType.SeaUrchin)
            {
                float currentSpeed = leftSpeed * GlobalSpeedManager.CurrentSpeed;
                enemyRigidBody.velocity = Vector2.left * currentSpeed;
            }
            else
            {
                enemyRigidBody.velocity = Vector2.left * leftSpeed;
            }
        }
    }

    public void EnemyElectrified()
    {
        isElectrified = true;
        enemyRigidBody.velocity = new Vector2(0, 0);
        enemyRigidBody.gravityScale = 2f;
    }
}
