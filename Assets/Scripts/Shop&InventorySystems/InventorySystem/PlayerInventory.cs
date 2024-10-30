using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    
    private List<ShopItem> purchasedItems = new List<ShopItem>();
    
    public event Action<ShopItem> onItemAdded;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
    public void AddItem(ShopItem item)
    {
        purchasedItems.Add(item);
        onItemAdded?.Invoke(item); 
    }
    
    public ShopItem[] GetPurchasedItems()
    {
        return purchasedItems.ToArray();
    }
    
    public bool HasItem(ShopItem item)
    {
        return purchasedItems.Contains(item);
    }
}
