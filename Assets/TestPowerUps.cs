using System;
using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UnityEngine;

public class TestPowerUps : MonoBehaviour
{
    [SerializeField] PowerUpManager powerUpManager;
    [SerializeField] GameObject shieldPowerUp;
    [SerializeField] GameObject miniPowerUp;
    [SerializeField] GameObject maxPowerUp;
    [SerializeField] GameObject lifePowerUp;
    public async void ActiveShield()
    {
        powerUpManager.ActivatePowerUp(shieldPowerUp.GetComponent<ShieldPowerUp>());
    }
    
    public async void ActiveMiniPowerUp()
    {
        powerUpManager.ActivatePowerUp(miniPowerUp.GetComponent<ResizePowerUp>());
    }
    
    public async void ActiveMaxPowerUp()
    {
        powerUpManager.ActivatePowerUp(maxPowerUp.GetComponent<ResizePowerUp>());
    }
    
    public async void ActiveLifePowerUp()
    {
        powerUpManager.ActivatePowerUp(lifePowerUp.GetComponent<AddLifePowerUp>());
    }
}
