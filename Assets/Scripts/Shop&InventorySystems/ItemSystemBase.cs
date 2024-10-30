using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSystemBase<T> : MonoBehaviour where T : ItemUIBase
{
    [SerializeField] protected RectTransform itemList;
    [SerializeField] protected T itemUIPrefab;

    protected List<T> itemsUI = new List<T>();

    protected void InitItems(List<ShopItem> items)
    {
        foreach (ShopItem item in items)
        {
            AddItemUI(item);
        }
    }

    protected void AddItemUI(ShopItem item)
    {
        T newItemUI = Instantiate(itemUIPrefab, itemList);
        newItemUI.Init(item);
        newItemUI.onItemSelected += OnItemSelected;
        itemsUI.Add(newItemUI);
    }

    protected abstract void OnItemSelected(ItemUIBase item);
}