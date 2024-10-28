using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
    public string title;
    public Sprite itemIcon;
    public int price;
    public string description;
    public ShopItem item;
}