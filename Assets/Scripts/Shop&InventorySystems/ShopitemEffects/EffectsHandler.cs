using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    public static EffectsHandler Instance { get; private set; }

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

    public void ChangeMainCharacter()
    {
        Debug.Log("Changing Main Character");
    }
}
