using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Singleton instance for easy access
    public static PlayerInventory instance;

    // List to store purchased items
    private List<ShopItem> purchasedItems = new List<ShopItem>();

    // Event to notify listeners when the inventory changes
    public event Action<ShopItem> onItemAdded;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    /// <summary>
    /// Adds a new item to the inventory.
    /// </summary>
    /// <param name="item">The purchased item.</param>
    public void AddItem(ShopItem item)
    {
        purchasedItems.Add(item);
        onItemAdded?.Invoke(item); // Notify listeners of the new item
    }

    /// <summary>
    /// Returns an array of all purchased items.
    /// </summary>
    public ShopItem[] GetPurchasedItems()
    {
        return purchasedItems.ToArray();
    }

    /// <summary>
    /// Checks if the player has a specific item.
    /// </summary>
    /// <param name="item">The item to check.</param>
    public bool HasItem(ShopItem item)
    {
        return purchasedItems.Contains(item);
    }
}
