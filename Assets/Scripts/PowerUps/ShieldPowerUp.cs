using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UnityEngine;

public class ShieldPowerUp : BasePowerUp
{
    [SerializeField] private float shieldTime;

    public delegate void OnShieldPowerUpActivate();
    public static event OnShieldPowerUpActivate onShieldPowerUpActivate;
    
    public delegate void OnShieldPowerUpDeactivate();
    public static event OnShieldPowerUpDeactivate onShieldPowerUpDeactivate;
    
    private void Start()
    {
        SetPowerUpTime(shieldTime);
        
    }

    protected override void ActivePowerUp()
    {
        onShieldPowerUpActivate?.Invoke();
    }

    protected override void DeactivatePowerUp()
    {
        onShieldPowerUpDeactivate?.Invoke();
    }

}
