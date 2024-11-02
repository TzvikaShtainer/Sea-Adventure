using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Effects/ChangeChangeMainCharacterEffect")]
public class ChangeMainCharacterEffect : ScriptableObject, IShopItemEffect
{
     public RuntimeAnimatorController  newAnimatorController;
    
    public void ApplyEffect(ShopItem shopItem)
    {
        EffectsHandler.Instance.ChangeMainCharacter(newAnimatorController);
    }
}
