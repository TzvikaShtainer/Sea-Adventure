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
    [SerializeField] private int hitDelay;
    
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private bool isTookPowerUp;
    
    [SerializeField] Transform playerTransform;

    [SerializeField] private GameObject shieldSprite;
    [SerializeField] private bool hasShield;
    
    [SerializeField] float originalTransform = 0.25f;
    [SerializeField] private Renderer playerSprite;
    
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
        //the null exp cuz bec i dont have an object pool i think
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
        
        await HandleHitEffect();
        
        isDamaged = false;
    }

    private async Task HandleHitEffect()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;

        float blinkDuration = 1f;
        float blinkInterval = 0.1f;

        float elapsedTime = 0f;
        
        while (elapsedTime < blinkDuration)
        {
            spriteRenderer.color = (elapsedTime % (blinkInterval * 2) < blinkInterval) ? Color.white : Color.red;
            
            float actualDelay = Mathf.Min(blinkInterval, blinkDuration - elapsedTime);
            await TimeUtils.WaitForGameTime(actualDelay);
            
            elapsedTime += actualDelay;
        }
        
        spriteRenderer.color = originalColor;
    }
    
    private void HandlePowerUp(Collider2D other)
    {
        BasePowerUp takeable = other.GetComponent<BasePowerUp>();

        if (takeable != null)
        {
            
            powerUpManager.ActivatePowerUp(takeable);
            
            takeable.gameObject.SetActive(false); //for now need to handle this in the power up
        }
        
    }

    public void SetPlayerSize(float newSize)
    {
        playerTransform.transform.localScale = 
            new Vector2(newSize, newSize);
    }

    public float GetPlayerSize()
    {
        return originalTransform;
    }
    
    private void AddLifePowerUp_OnAddLifePowerUp(float lifeAmtToAdd)
    {
        playerHealth.AddHealth(lifeAmtToAdd);

        ResetPowerUps();
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

        ResetPowerUps();
    }

    private void ResetPowerUps()
    {
        SetPlayerSize(originalTransform);
        playerSprite.enabled = true;
    }

    public Renderer GetSprite()
    {
        return playerSprite;
    }
}
