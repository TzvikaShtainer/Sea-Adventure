using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidBody;
    [SerializeField] private float leftSpeed;
    [SerializeField] private float accelerationRate = 10;
    private bool isElectrified;

    private void OnEnable()
    {
        isElectrified = false;
    }

    private void Update()
    {
        if (!isElectrified)
        {
            enemyRigidBody.velocity = Vector2.left * leftSpeed;
        }
    }

    public void EnemyElectrified()
    {
        isElectrified = true;
        enemyRigidBody.velocity = new Vector2(0, 0);
        enemyRigidBody.gravityScale = 1;
    }
}
