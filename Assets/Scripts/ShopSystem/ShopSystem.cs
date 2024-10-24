using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/ShopSystem")]
public class ShopSystem : ScriptableObject
{
    [SerializeField] private ShopItem[] shopItems;

    public ShopItem[] GetShopItems()
    {
        return shopItems;
    }

    public bool TryPurchase(ShopItem itemSelected)
    {
        return MoneyManager.instance.Purchase(itemSelected.price, itemSelected.item);
    }
}

