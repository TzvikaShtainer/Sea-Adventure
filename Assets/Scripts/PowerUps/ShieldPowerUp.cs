using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UnityEngine;

public class ShieldPowerUp : BasePowerUp
{
    [SerializeField] private float shieldTime;
    [SerializeField] private float blinkEffectTime;

    public delegate void OnShieldPowerUpActivate();
    public static event OnShieldPowerUpActivate onShieldPowerUpActivate;
    
    public delegate void OnShieldPowerUpDeactivate();
    public static event OnShieldPowerUpDeactivate onShieldPowerUpDeactivate;
    
    void Start()
    {
        SetPowerUpTime(shieldTime, blinkEffectTime);
    }

    protected override void ActivePowerUp()
    {
        //Debug.Log("ShieldPowerUp");
        onShieldPowerUpActivate?.Invoke();
    }

    protected override void DeactivatePowerUp()
    {
        onShieldPowerUpDeactivate?.Invoke();
    }

}
