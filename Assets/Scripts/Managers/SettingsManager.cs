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
        //init character
    }

    private void Update()
    {
        Debug.Log("working");
    }

    private static void InitBgColorFromGameData()
    {
        string currentBgColor = GameDataHandler.instance.GetBgCurrentColor();
        Debug.Log(currentBgColor);
        ShopItem item = Resources.Load<ShopItem>($"ShopItems/{currentBgColor}");
        Debug.Log(item);
        
        item.UseItem();
    }
    
    
}
