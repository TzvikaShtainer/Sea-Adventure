using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    
    public delegate void OnHealthChange(float health, float amt, float maxHealth);
    public delegate void OnDeath();

    public static event OnHealthChange onHealthChange;
    public static event OnDeath onDeath;

    private void Start()
    {
        SetHealth(health);
    }

    public void TakeDamage(float amt)
    {
        if (amt == 0 || health == 0) return;
        
        health -= amt;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        
        onHealthChange?.Invoke(health, amt, maxHealth);

        if (health <= 0)
        {
            health = 0;
            onDeath?.Invoke();
        }
    }

    public void SetHealth(float healthValue)
    {
        health = healthValue;
        
        onHealthChange?.Invoke(health, 0, maxHealth);
    }

    public float GetCurrHealth()
    {
        return health;
    }

    public void AddHealth(float amount)
    {
        health += amount;
        
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        
        onHealthChange?.Invoke(health, amount, maxHealth);
    }
}
