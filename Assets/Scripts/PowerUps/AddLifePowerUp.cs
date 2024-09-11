using System;
using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UnityEngine;

public class AddLifePowerUp : BasePowerUp
{
    [SerializeField] private float lifeAmtToAdd;
    public delegate void OnAddLifePowerUp(float lifeAmtToAdd);
    public static event OnAddLifePowerUp onAddLifePowerUp;



    protected override void ActivePowerUp()
    {
        onAddLifePowerUp?.Invoke(lifeAmtToAdd);
    }
}
