using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnPlayerDeath(); 
    public static event OnPlayerDeath onPlayerDeath;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            onPlayerDeath?.Invoke();
        }
    }
}
