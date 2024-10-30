using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    }
    

    private void Start()
    {
         InitItems(inventorySystem.GetInventoryItems());
         
         UpdateMoney(MoneyManager.instance.GetMoneyAmount(), 0);
    }

    protected override void OnItemSelected(ItemUIBase item)
    {
        selectedItem = (ShopItemUI)item;
        // Handle inventory-specific logic here
    }
    
    private void UpdateMoney(int currMoneyAmount, int newMoneyAmount)
    {
        moneyText.SetText(currMoneyAmount.ToString());
        
        //DestroyItemsUI();
        
        //InitItems(inventorySystem.GetInventoryItems());
    }
}
