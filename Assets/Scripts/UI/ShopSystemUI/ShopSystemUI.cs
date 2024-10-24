using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystemUI : MonoBehaviour
{
    [SerializeField] private ShopSystem shopSystem;
    [SerializeField] private ShopItemUI shopItemUIPrefab;
    [SerializeField] private RectTransform shopList;
    [SerializeField] private UIManager uiManager;
    
    [SerializeField] private Button backBtn;
    [SerializeField] private Button buyBtn;
    [SerializeField] private TextMeshProUGUI MoneyText;
    
    [SerializeField] private List<ShopItemUI> shopItems = new List<ShopItemUI>();
    
    [SerializeField] private ShopItemUI selectedItem;

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
        InitShopItems();
        
        //backBtn.onClick.AddListener(uiManager.OnReturnClicked); //added with unity events
        buyBtn.onClick.AddListener(TryPurchaseItem);
        
        UpdateMoney(MoneyManager.instance.GetMoneyAmount(), 0);
    }

    private void InitShopItems()
    {
        ShopItem[] shopItems = shopSystem.GetShopItems();
        foreach (ShopItem item in shopItems)
        {
            AddShopItem(item);
        }
    }
        
    private void AddShopItem(ShopItem item)
    { 
        ShopItemUI newItemUi = Instantiate(shopItemUIPrefab, shopList);
        newItemUi.Init(item, MoneyManager.instance.GetMoneyAmount());
        //newItemUi.Init(item, creditComponent.Credit);
        newItemUi.onItemSelected += ItemSelected;
        shopItems.Add(newItemUi);
    }

    private void ItemSelected(ShopItemUI item)
    {
        this.selectedItem = item;
    }
        
    private void TryPurchaseItem()
    {
        if (!selectedItem || !shopSystem.TryPurchase(selectedItem.GetItem()))
            return;

        RemoveItem(selectedItem);
    }

    private void RemoveItem(ShopItemUI itemToRemove)
    {
        shopItems.Remove(itemToRemove);
        Destroy(itemToRemove.gameObject);
    }

    private void UpdateMoney(int currMoneyAmount, int newMoneyAmount)
    {
        MoneyText.SetText(currMoneyAmount.ToString());
        //RefreshItems();
    }

    private void RefreshItems()
    {
        foreach (ShopItemUI shopItemUI in shopItems)
        {
            //shopItemUI.Refresh(creditComponent.Credit);
        }
    }
}
