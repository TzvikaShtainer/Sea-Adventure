using Player;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    public static EffectsHandler Instance { get; private set; }
    
    [SerializeField] private GameObject player;

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

    public void ChangeMainCharacter(RuntimeAnimatorController newAnimatorController)
    {
        PlayerAnimationController playerAnimationController = player.GetComponent<PlayerAnimationController>();
        playerAnimationController.SetAnimator(newAnimatorController);
    }
}
