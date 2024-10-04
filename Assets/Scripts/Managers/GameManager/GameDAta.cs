using System;

namespace DefaultNamespace.GameManager
{
    [Serializable]
    public class GameData
    {
        public float MaxDistanceTraveled;
        public int MoneyAmount;

        public GameData()
        {
            // Initialize default values
            MaxDistanceTraveled = 0f;
            MoneyAmount = 0;
        }
    }
}