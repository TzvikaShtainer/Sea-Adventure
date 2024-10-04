using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler instance;
    
    [SerializeField] GameDataSO gameDataSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetMaxDistanceTraveled()
    {
        return gameDataSO.MaxDistanceTraveled;
    }

    public void SetMaxDistanceTraveled(float newValue)
    {
        gameDataSO.MaxDistanceTraveled = newValue;
    }
    
    public int GetMoneyAmount()
    {
        return gameDataSO.MoneyAmount;
    }

    public void SetMoneyAmount(int newValue)
    {
        gameDataSO.MoneyAmount = newValue;
    }
}
