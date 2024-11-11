using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[CreateAssetMenu(menuName = "Shop/Effects/ChangeChangeMainCharacterEffect")]
public class ChangeMainCharacterEffect : ScriptableObject, IShopItemEffect
{
     public RuntimeAnimatorController  newAnimatorController;

     [Header("CapsuleCollider2D 1")] 
     public Vector2[] CollidersOffsets;

     [Header("Shield Pos")] 
     public Vector3 shieldPos;
    
    public void ApplyEffect(ShopItem shopItem)
    {
        EffectsHandler.Instance.ChangeMainCharacter(newAnimatorController, CollidersOffsets, shieldPos);
    }
}
