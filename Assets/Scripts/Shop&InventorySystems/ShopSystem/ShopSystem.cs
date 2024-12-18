using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/ShopSystem")]
public class ShopSystem :  ScriptableObject
{
    [SerializeField] private List<ShopItem> shopItems = new List<ShopItem>();

    public List<ShopItem> GetShopItems()
    {
        return shopItems;
    }

    public bool TryPurchase(ShopItem itemSelected)
    {
        return MoneyManager.instance.Purchase(itemSelected.price, itemSelected.item);
    }
    
    public void LoadShopItemsFromResources()
    {
        shopItems.Clear();
        
        ShopItem[] items = Resources.LoadAll<ShopItem>("ShopItems");
        
        shopItems.AddRange(items);

        OrderList();
    }
    
    private void OrderList()
    {
        ShopItemType[] customOrder = {
            ShopItemType.CharacterType, 
            ShopItemType.Background
        };

        shopItems = shopItems
            .OrderBy(item => System.Array.IndexOf(customOrder, item.shopItemType))
            .ToList();
    }
}
