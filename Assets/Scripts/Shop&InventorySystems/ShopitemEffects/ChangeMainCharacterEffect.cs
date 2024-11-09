using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Effects/ChangeChangeMainCharacterEffect")]
public class ChangeMainCharacterEffect : ScriptableObject, IShopItemEffect
{
     public RuntimeAnimatorController  newAnimatorController;

     [Header("CapsuleCollider2D 1")] 
     public Vector2[] CollidersOffsets;
     
     // [Header("CapsuleCollider2D 2")]
     // public CapsuleCollider2D collider2;
     // public int offsetX2;
     // public int offsetY2;
     //
     // [Header("CapsuleCollider2D 1")]
     // public CapsuleCollider2D collider3;
     // public int offsetX3;
     // public int offsetY3;
     //
     // [Header("CircleCollider2D 4")]
     // public CircleCollider2D collider4;
     // public int offsetX4;
     // public int offsetY4;
    
    public void ApplyEffect(ShopItem shopItem)
    {
        EffectsHandler.Instance.ChangeMainCharacter(newAnimatorController, CollidersOffsets);
    }
}
