using System;
using System.Collections;
using System.Collections.Generic;
using PowerUps;
using Unity.VisualScripting;
using UnityEngine;

public class AddLifePowerUp : BasePowerUp
{
    [SerializeField] private float lifeAmtToAdd;
    public delegate void OnAddLifePowerUpActivate(float lifeAmtToAdd);
    public static event OnAddLifePowerUpActivate onAddLifePowerUpActivate;


    void Start()
    {
        SetPowerUpTime(0, 0);
    }

    protected override void ActivePowerUp()
    {
        onAddLifePowerUpActivate?.Invoke(lifeAmtToAdd);
    }
}
