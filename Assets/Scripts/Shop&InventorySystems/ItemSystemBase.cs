using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSystemBase<T> : MonoBehaviour where T : ItemUIBase
{
    [SerializeField] protected RectTransform itemList;
    [SerializeField] protected T itemUIPrefab;

    protected List<T> itemsUI = new List<T>();

    protected void InitItems(List<ShopItem> items, bool isInventory)
    {
        foreach (ShopItem item in items)
        {
            AddItemUI(item, isInventory);
        }
    }

    protected void AddItemUI(ShopItem item, bool isInventory)
    {
        T newItemUI = Instantiate(itemUIPrefab, itemList);
        newItemUI.Init(item);
        newItemUI.onItemSelected += OnItemSelected;
        itemsUI.Add(newItemUI);
        
        if(isInventory)
            newItemUI.SetPriceTransformDisable();
        
        itemsUI.Clear(); //i dont know why but it ordered the inventory items after buying new item
    }

    protected abstract void OnItemSelected(ItemUIBase item);
    
    
}