using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemUI : ItemUIBase
{
    public void Init(ShopItem item, int availableCredits)
    {
        base.Init(item);
        
        Refresh(availableCredits);
    }

    public void Refresh(int availableCredits)
    {
        priceText.color = availableCredits >= item.price 
            ? Color.green : Color.red;
    }
}
