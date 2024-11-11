using System;
using System.Numerics;
using Player;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EffectsHandler : MonoBehaviour
{
    public static EffectsHandler Instance { get; private set; }
    
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D[] colliders;
    [SerializeField] private Transform shieldTransform;


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

    private void Start()
    {
        if (shieldTransform == null)
        {
            shieldTransform = player.transform.Find("PowerUps").Find("Bubble_Small");
        }
    }

    public void ChangeBackgroundColor(Sprite[] backgroundSprites)
    {
        BackGroundManager.Instance.ChangeBackGround(backgroundSprites);
    }

    public void ChangeMainCharacter(RuntimeAnimatorController newAnimatorController, Vector2[] offset, Vector3 shieldPos)
    {
        SetAnimator(newAnimatorController);

        SetColliders(offset);

        SetShieldPosition(shieldPos);
    }

    private void SetAnimator(RuntimeAnimatorController newAnimatorController)
    {
        PlayerAnimationController playerAnimationController = player.GetComponent<PlayerAnimationController>();
        playerAnimationController.SetAnimator(newAnimatorController);
    }
    
    private void SetColliders(Vector2[] offset)
    {
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
    
    private void SetShieldPosition(Vector3 shieldPos)
    {
        shieldTransform.localPosition = shieldPos;
    }
}
