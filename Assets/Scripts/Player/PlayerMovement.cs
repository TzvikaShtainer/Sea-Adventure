using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private float jumpForce;     
    [SerializeField] private float maxVerticalSpeed = 5f;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    
    [SerializeField] private float smoothingTime = 0.1f; 
    private float currentVelocityY;
    
    private bool isJumping = false;
    private bool isTouching = false;
    [SerializeField] private bool isTouchInput;

    private void OnEnable()
    {
        TouchInputHandler.onStickValueUpdated += TouchInputHandler_OnStickValueUpdated;
    }
    
    private void OnDisable()
    {
        TouchInputHandler.onStickValueUpdated -= TouchInputHandler_OnStickValueUpdated;
    }

    void Update()
    {
        HandleMovement();
        HandleTouchInput();  // Added to handle touch logic
    }

    void FixedUpdate()
    {
        // Ensure horizontal velocity remains zero if the player should not move horizontally
        rb.velocity = new Vector2(0, rb.velocity.y);

        HandleBoundaries();
    }

    private void TouchInputHandler_OnStickValueUpdated(bool isGettingTouchInputValue)
    {
        isTouchInput = isGettingTouchInputValue;
    }

    private void HandleBoundaries()
    {
        if (transform.position.y > maxY)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.SmoothDamp(rb.velocity.y, 0, ref currentVelocityY, smoothingTime));
            transform.position = new Vector2(transform.position.x, Mathf.Min(transform.position.y, maxY));
        }
        else if (transform.position.y < minY)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.SmoothDamp(rb.velocity.y, 0, ref currentVelocityY, smoothingTime));
            transform.position = new Vector2(transform.position.x, Mathf.Max(transform.position.y, minY));
        }
    }

    private void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PlayJumpSound();
        }

        if (Input.GetKey(KeyCode.Space) || isTouchInput)
        {
            Jump();
        }

        if (rb.velocity.y > maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxVerticalSpeed);
        }
        else if (rb.velocity.y < -maxVerticalSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxVerticalSpeed);
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isTouching && Time.timeScale != 0)
            {
                isTouching = true;
                PlayJumpSound();
                Jump();
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
    }

    void PlayJumpSound()
    {
        SoundManager.instance.PlayOneShot(FModEvents.instance.JumpSound, transform.position);
    }

    public bool GetJumpState()
    {
        return isJumping;
    }

    public void ReturnToIdleState()
    {
        isJumping = false;
    }
}
