using System;
using System.Collections.Generic;

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
            bgCurrentColor = "ShopItem_BG_Blue_Default";
        }
    }
}