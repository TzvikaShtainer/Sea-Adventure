using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidBody;
    [SerializeField] private float leftSpeed;

    private void Update()
    {
        enemyRigidBody.velocity = Vector2.left * leftSpeed; 
    }
}
