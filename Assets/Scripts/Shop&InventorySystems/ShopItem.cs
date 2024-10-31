using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
    public string title;
    public Sprite itemIcon;
    public int price;
    public string description;
    public ShopItem item;
    
    public List<ScriptableObject> effects = new List<ScriptableObject>();

    public void UseItem()
    {
        foreach (var effect in effects)
        {
            if (effect is IShopItemEffect shopEffect)
            {
                shopEffect.ApplyEffect(this);
            }
            else
            {
                Debug.LogWarning($"{effect.name} does not implement IShopItemEffect.");
            }
        }
    }
}