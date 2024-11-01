using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.GameManager
{
    [Serializable]
    public class GameData
    {
        public float MaxDistanceTraveled;
        public int MoneyAmount;
        public bool tutorialCompleted;
        
        public List<string> inventoryItemIDs;

        public string bgCurrentColor;

        public GameData()
        {
            // Initialize default values
            MaxDistanceTraveled = 0f;
            MoneyAmount = 0;
            tutorialCompleted = false;
            
            inventoryItemIDs = new List<string>();
            inventoryItemIDs.Add("ShopItem_BG_Blue_Default");

            bgCurrentColor = "ShopItem_BG_Blue_Default";
        }
    }
}