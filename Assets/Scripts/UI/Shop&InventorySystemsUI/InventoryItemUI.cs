using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemUI : ItemUIBase
{
    public void Init(ShopItem item)
    {
        base.Init(item);

        priceText.gameObject.SetActive(false); //set off the money text
    }
}
