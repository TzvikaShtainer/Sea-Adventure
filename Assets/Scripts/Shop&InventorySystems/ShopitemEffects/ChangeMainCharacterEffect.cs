using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Effects/ChangeChangeMainCharacterEffect")]
public class ChangeMainCharacterEffect : ScriptableObject, IShopItemEffect
{
    public void ApplyEffect(ShopItem shopItem)
    {
        EffectsHandler.Instance.ChangeMainCharacter();
    }
}
