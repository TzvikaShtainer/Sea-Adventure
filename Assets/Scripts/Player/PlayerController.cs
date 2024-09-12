using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerUps;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [SerializeField]private PlayerHealthSystem playerHealth;
    [SerializeField] private bool isDamaged;
    
    [SerializeField] Transform playerTransform;

    [SerializeField] private GameObject shieldSprite;
    [SerializeField] private bool hasShield;
    
    public delegate void OnPlayerHasShield();
    public event OnPlayerHasShield onPlayerHasShield;
    
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
    
    private void OnEnable()
    {
        AddLifePowerUp.onAddLifePowerUpActivate += AddLifePowerUp_OnAddLifePowerUp;
        ShieldPowerUp.onShieldPowerUpActivate += ShieldPowerUp_OnShieldPowerUpActivate;
        ShieldPowerUp.onShieldPowerUpDeactivate += ShieldPowerUp_OnShieldPowerUpDeactivate;
    }

    private void OnDisable()
    {
        AddLifePowerUp.onAddLifePowerUpActivate -= AddLifePowerUp_OnAddLifePowerUp;
        ShieldPowerUp.onShieldPowerUpActivate -= ShieldPowerUp_OnShieldPowerUpActivate;
        ShieldPowerUp.onShieldPowerUpDeactivate -= ShieldPowerUp_OnShieldPowerUpDeactivate;
    }

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isDamaged)
        {
            if (hasShield)
            {
                BaseEnemy enemy = other.GetComponent<BaseEnemy>();
                enemy.Electrified();
            }
            else
            {
                await HandleDamage();
            }
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
    
    private void AddLifePowerUp_OnAddLifePowerUp(float lifeAmtToAdd)
    {
        playerHealth.AddHealth(lifeAmtToAdd);
    }
    
    private void ShieldPowerUp_OnShieldPowerUpActivate()
    {
        hasShield = true;
        shieldSprite.SetActive(true);
    }
    
    private void ShieldPowerUp_OnShieldPowerUpDeactivate()
    {
        hasShield = false;
        shieldSprite.SetActive(false);
    }
}
