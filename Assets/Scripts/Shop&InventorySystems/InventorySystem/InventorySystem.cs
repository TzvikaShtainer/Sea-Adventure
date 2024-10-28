using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/InventorySystem")]
public class InventorySystem :  ScriptableObject
{
    [SerializeField] private List<ShopItem> inventoryItems = new List<ShopItem>();

    public List<ShopItem> GetInventoryItems()
    {
        return inventoryItems;
    }

    public void AddItem(ShopItem newItem)
    {
        if (!inventoryItems.Contains(newItem))
        {
            inventoryItems.Add(newItem);
        }
    }

    public bool RemoveItem(ShopItem itemToRemove)
    {
        return inventoryItems.Remove(itemToRemove);
    }

    public bool TryUse(ShopItem itemSelected)
    {
        if (inventoryItems.Contains(itemSelected) && 
            MoneyManager.instance.Purchase(itemSelected.price, itemSelected.item))
        {
            //inventoryItems.Remove(itemSelected);
            return true;
        }
        return false;
    }
}
