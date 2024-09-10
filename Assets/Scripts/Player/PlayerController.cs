using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerUps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [SerializeField]private PlayerHealthSystem playerHealth;
    [SerializeField] private bool isDamaged;
    
    [SerializeField] Transform playerTransform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isDamaged)
        {
             await HandleDamage();
        }

        if (other.CompareTag("PowerUp"))
        {
            HandlePowerUp(other);
        }
    }

    private async Task HandleDamage()
    {
        playerHealth.TakeDamage(1); //all enemies do the same damage for now
        isDamaged = true;
        await Task.Delay(1000);
        
        isDamaged = false;
    }
    
    private static void HandlePowerUp(Collider2D other)
    {
        BasePowerUp takeable = other.GetComponent<BasePowerUp>();
        
        takeable.Active();
        
        other.gameObject.SetActive(false);
    }

    public void SetPlayerSize(float newSize)
    {
        playerTransform.transform.localScale = 
            new Vector2(newSize, newSize);
    }

    public float GetPlayerSize()
    {
        return playerTransform.transform.localScale.x;
    }
}
