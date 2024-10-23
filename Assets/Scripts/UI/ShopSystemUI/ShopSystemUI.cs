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
    
    private ShopItemUI selectedItem;
    
    private void OnDisable()
    {
        //creditComponent.onCreditsChanged -= UpdateCredit;
    }
    
    private void Start()
    {
        InitShopItems();
        //backBtn.onClick.AddListener(uiManager.OnReturnClicked);
        //buyBtn.onClick.AddListener(TryPurchaseItem);
        //creditComponent.onCreditsChanged += UpdateCredit;
        UpdateMoney(MoneyManager.instance.GetMoneyAmount());
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
        // if (!selectedItem || !shopSystem.TryPurchase(selectedItem.GetItem(), creditComponent))
        //     return;

        RemoveItem(selectedItem);
    }

    private void RemoveItem(ShopItemUI itemToRemove)
    {
        shopItems.Remove(itemToRemove);
        Destroy(itemToRemove.gameObject);
    }

    private void UpdateMoney(int newMoneyAmount)
    {
        MoneyText.SetText(newMoneyAmount.ToString());
        RefreshItems();
    }

    private void RefreshItems()
    {
        foreach (ShopItemUI shopItemUI in shopItems)
        {
            //shopItemUI.Refresh(creditComponent.Credit);
        }
    }
}
