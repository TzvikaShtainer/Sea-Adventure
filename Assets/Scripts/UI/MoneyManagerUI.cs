using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MoneyManagerUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI moneyText;

        private void OnEnable()
        {
            MoneyManager.onMoneyAmountChanged += MoneyManager_OnMoneyAmountChanged;
        }

        private void OnDisable()
        {
            MoneyManager.onMoneyAmountChanged -= MoneyManager_OnMoneyAmountChanged;
        }
        
        private void MoneyManager_OnMoneyAmountChanged(int currMoneyAmount, int amountToAdd)
        {
            UpdateVisuals(currMoneyAmount, amountToAdd);
        }

        private void UpdateVisuals(int currMoneyAmount, int amountToAdd)
        {
            moneyText.text = currMoneyAmount.ToString();
        }
    }
}