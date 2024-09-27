using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    
    [SerializeField] private MoneyAmountSO moneyAmountSO;
    [SerializeField] private int currMoneyAmount;
    
    public delegate void OnMoneyAmountChanged(int currMoneyAmount, int amountToAdd);
    public static event OnMoneyAmountChanged onMoneyAmountChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        SetMoney(moneyAmountSO.moneyAmount);
    }
    
    private void OnEnable()
    {
        PlayerHealthSystem.onDeath += PlayerHealthSystem_OnDeath;
    }

    private void OnDisable()
    {
        PlayerHealthSystem.onDeath -= PlayerHealthSystem_OnDeath;
    }
    
    private void PlayerHealthSystem_OnDeath()
    {
        SaveMoneyAmount(currMoneyAmount);
    }

    private void SetMoney(int newMoneyAmount)
    {
        currMoneyAmount = newMoneyAmount;
        
        onMoneyAmountChanged?.Invoke(currMoneyAmount ,newMoneyAmount);
    }

    public void ChangeMoneyAmount(int amountToAdd)
    {
        currMoneyAmount += amountToAdd;
        
        onMoneyAmountChanged?.Invoke(currMoneyAmount, amountToAdd);
    }

    public void SaveMoneyAmount(int newMoneyAmount)
    {
        moneyAmountSO.moneyAmount = newMoneyAmount;
    }
}
