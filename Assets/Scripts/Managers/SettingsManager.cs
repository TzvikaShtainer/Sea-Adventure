using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

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
        InitBgColorFromGameData();
        InitCharacter();
    }

    private static void InitBgColorFromGameData()
    {
        string currentBgColor = GameDataHandler.instance.GetBgCurrentColor();
        ShopItem item = Resources.Load<ShopItem>($"ShopItems/{currentBgColor}");
        item.UseItem();
    }
    
    private void InitCharacter()
    {
        string currentCharacter = GameDataHandler.instance.GetCurrentCharacter();
        ShopItem item = Resources.Load<ShopItem>($"ShopItems/{currentCharacter}");
        item.UseItem();
    }
    
}
