using Player;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    public static EffectsHandler Instance { get; private set; }
    
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D[] colliders;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeBackgroundColor(Sprite[] backgroundSprites)
    {
        BackGroundManager.Instance.ChangeBackGround(backgroundSprites);
    }

    public void ChangeMainCharacter(RuntimeAnimatorController newAnimatorController, Vector2[] offset)
    {
        PlayerAnimationController playerAnimationController = player.GetComponent<PlayerAnimationController>();
        playerAnimationController.SetAnimator(newAnimatorController);
        
        colliders = player.GetComponents<Collider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            SetOffsetX(offset[i].x, i);

            SettOffsetY(offset[i].y, i);
        }
    }
    
    private void SetOffsetX(float offsetX, int i)
    {
        Vector2  centerX = colliders[i].offset;
        centerX.x = offsetX;
        colliders[i].offset = centerX;
    }
    
    private void SettOffsetY(float offsetY, int i)
    {
        Vector2  centerY = colliders[i].offset;
        centerY.y = offsetY;
        colliders[i].offset = centerY;
    }
}
