using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Effects/ChangeBackgroundColor")]
public class ChangeBackgroundColorEffect : ScriptableObject, IShopItemEffect
{
    [SerializeField] string backgroundColorName;
    
    [SerializeField] Sprite[] backgroundSprites;
    
    public void ApplyEffect(ShopItem shopItem)
    {
        //EffectsHandler.Instance.ChangeBackgroundColor();
        BackGroundManager.Instance.ChangeBackGround(backgroundSprites);
        //need to save effect
    }
}