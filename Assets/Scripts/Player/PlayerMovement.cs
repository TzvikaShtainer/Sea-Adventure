using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private float thrustForce = 10f;     
    [SerializeField] private float maxVerticalSpeed = 5f; 
    
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        
        if (rb.velocity.y > maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVerticalSpeed);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void Thrust()
    {
        rb.AddForce(Vector2.up * thrustForce, ForceMode2D.Force);
    }
}
