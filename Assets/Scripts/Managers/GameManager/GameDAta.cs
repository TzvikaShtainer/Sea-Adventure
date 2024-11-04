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

        public string mainCharacter;

        public GameData()
        {
            MaxDistanceTraveled = 0f;
            MoneyAmount = 0;
            tutorialCompleted = false;
            
            inventoryItemIDs = new List<string>();

             if (!inventoryItemIDs.Contains("ShopItem_BG_Blue_Default"))
             {
                 inventoryItemIDs.Add("ShopItem_BG_Blue_Default");
             }
            
             if (!inventoryItemIDs.Contains("ShopItem_default_Character"))
             {
                 inventoryItemIDs.Add("ShopItem_default_Character");
             }

            bgCurrentColor = "ShopItem_BG_Blue_Default";
            
            mainCharacter = "ShopItem_default_Character";
        }
    }
}