using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : ItemSystemBase<ShopItemUI>
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private Button useBtn;
    [SerializeField] private TextMeshProUGUI moneyText;
    
    private ShopItemUI selectedItem;
    
    private void OnEnable()
    {
        MoneyManager.onMoneyAmountChanged += UpdateMoney;

    }
    private void OnDestroy()
    {
        MoneyManager.onMoneyAmountChanged -= UpdateMoney;
        inventorySystem.onItemAddedToInventory -= InventorySystem_onItemAdded;
    }
    

    private void Start()
    {
         InitItems(inventorySystem.GetInventoryItems());
         
         UpdateMoney(MoneyManager.instance.GetMoneyAmount(), 0);
         
         inventorySystem.onItemAddedToInventory += InventorySystem_onItemAdded;
    }

    protected override void OnItemSelected(ItemUIBase item)
    {
        selectedItem = (ShopItemUI)item;
        // Handle inventory-specific logic here
    }
    
    private void UpdateMoney(int currMoneyAmount, int newMoneyAmount)
    {
        moneyText.SetText(currMoneyAmount.ToString());
    }
    
    private void InventorySystem_onItemAdded(ShopItem item)
    {
        AddItemUI(item);
    }
}
