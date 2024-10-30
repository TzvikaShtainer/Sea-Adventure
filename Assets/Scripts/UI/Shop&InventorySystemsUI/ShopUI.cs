using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : ItemSystemBase<ShopItemUI>
{
    [SerializeField] private ShopSystem shopSystem;
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private Button buyBtn;
    [SerializeField] private TextMeshProUGUI moneyText;

    private ShopItemUI selectedItem;

    private void OnEnable()
    {
        MoneyManager.onMoneyAmountChanged += UpdateMoney;
    }

    private void OnDisable()
    {
        MoneyManager.onMoneyAmountChanged -= UpdateMoney;
    }
    
    private void Start()
    {
        DeleteItemsThatPlayerAlreadyHave();
        
        InitItems(shopSystem.GetShopItems());
        
        buyBtn.onClick.AddListener(TryPurchaseItem);
        
        UpdateMoney(MoneyManager.instance.GetMoneyAmount(), 0);
    }
    
    private void DeleteItemsThatPlayerAlreadyHave()
    {
        List<ShopItem> shopItems = shopSystem.GetShopItems();
        List<ShopItem> inventoryItems = inventorySystem.GetInventoryItems();

        for (int i = shopItems.Count - 1; i >= 0; i--)
        {
            if (inventoryItems.Contains(shopItems[i]))
            {
                shopItems.RemoveAt(i);
            }
        }
    }

    private void UpdateMoney(int currMoneyAmount, int newMoneyAmount)
    {
        moneyText.SetText(currMoneyAmount.ToString());
    }
    

    protected override void OnItemSelected(ItemUIBase item)
    {
        selectedItem = (ShopItemUI)item;
    }

    private void TryPurchaseItem()
    {
        if (selectedItem != null && shopSystem.TryPurchase(selectedItem.GetItem()))
        {
            inventorySystem.AddItem(selectedItem.GetItem());
            itemsUI.Remove(selectedItem);
            Destroy(selectedItem.gameObject);
        }
    }
}
