using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidBody;
    [SerializeField] private float leftSpeed;
    [SerializeField] private float accelerationRate = 10;

    private void Update()
    {
        enemyRigidBody.velocity = Vector2.left * leftSpeed;
    }
    
}
