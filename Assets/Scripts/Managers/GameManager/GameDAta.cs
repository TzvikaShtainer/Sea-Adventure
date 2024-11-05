using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.GameManager
{
    [Serializable]
    public class GameData
    {
        //  C:\Users\tzvik\AppData\LocalLow\DefaultCompany\SeaAdventure - full path
        
        public float MaxDistanceTraveled;
        public int MoneyAmount;
        public bool tutorialCompleted;
        
        public List<string> inventoryItemIDs;

        public string bgCurrentColor;

        public string mainCharacter;

        private string bgCurrentColorString = "ShopItem_BG_Blue_Default";
        
        private string mainCharacterString = "ShopItem_default_Character";

        public GameData()
        {
            MaxDistanceTraveled = 0f;
            MoneyAmount = 0;
            tutorialCompleted = false;
            
            inventoryItemIDs = new List<string>();

            bgCurrentColor = bgCurrentColorString;
            
            mainCharacter = mainCharacterString;
        }

        public void CheckDataValid()
        {
            if (!inventoryItemIDs.Contains(bgCurrentColorString))
            {
                inventoryItemIDs.Add(bgCurrentColorString);
            }
            
            if (!inventoryItemIDs.Contains(mainCharacterString))
            {
                inventoryItemIDs.Add(mainCharacterString);
            }
        }
    }
}