using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private float jumpForce = 10f;     
    [SerializeField] private float maxVerticalSpeed = 5f;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    
    [SerializeField] private float smoothingTime = 0.1f; 
    private float currentVelocityY;

    void Update()
    {
        HandleMovement();
    }

    void FixedUpdate()
    {
        // Ensure horizontal velocity remains zero if the player should not move horizontally
        rb.velocity = new Vector2(0, rb.velocity.y);

        HandleBoundaries();
    }

    private void HandleBoundaries()
    {
        // Smoothly clamp the velocity when reaching the maxY boundary
        if (transform.position.y > maxY)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.SmoothDamp(rb.velocity.y, 0, ref currentVelocityY, smoothingTime));
            transform.position = new Vector2(transform.position.x, Mathf.Min(transform.position.y, maxY));
        }
        // Smoothly clamp the velocity when reaching the minY boundary
        else if (transform.position.y < minY)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.SmoothDamp(rb.velocity.y, 0, ref currentVelocityY, smoothingTime));
            transform.position = new Vector2(transform.position.x, Mathf.Max(transform.position.y, minY));
        }
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        // Clamp vertical speed if it exceeds maxVerticalSpeed
        if (rb.velocity.y > maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVerticalSpeed);
        }
        else if (rb.velocity.y < -maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxVerticalSpeed);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }
}
