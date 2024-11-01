using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/InventorySystem")]
public class InventorySystem :  ScriptableObject
{
    [SerializeField] private List<ShopItem> inventoryItems = new List<ShopItem>();
    
    public delegate void OnItemAdded(ShopItem item);
    public event OnItemAdded onItemAddedToInventory;

    public List<ShopItem> GetInventoryItems()
    {
        return inventoryItems;
    }

    public void AddItem(ShopItem newItem)
    {
        if (!inventoryItems.Contains(newItem))
        {
            inventoryItems.Add(newItem);
            
            onItemAddedToInventory?.Invoke(newItem);
            
            GameDataHandler.instance.SaveGameData();
        }
    }
    
    public void LoadInventoryFromIDs(List<string> itemIDs)
    {
        inventoryItems.Clear();
        
        foreach (string id in itemIDs)
        {
            ShopItem item = Resources.Load<ShopItem>($"ShopItems/{id}");
            if (item != null)
                inventoryItems.Add(item);
        }
    }
    
    
    public List<string> GetInventoryIDs()
    {
        return inventoryItems.Select(item => item.name).ToList();
    }
}
