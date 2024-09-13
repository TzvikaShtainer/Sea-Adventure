using UnityEngine;

namespace PowerUps
{
    public enum PowerUpType
    {
        AddLife,
        MaxSize,
        MinSize,
        Shield
    }
    
    public class PowerUpFactory
    {
        public BasePowerUp CreatePowerUp(PowerUpType powerUpType, Vector2 spawnPosition)
        {
            BasePowerUp powerUpToCreate = null;

            switch (powerUpType)
            {
                case PowerUpType.AddLife:
                    powerUpToCreate = Object.Instantiate(Resources.Load<BasePowerUp>("PowerUps/AddLifePowerUp"));
                    break;
            
                case PowerUpType.MaxSize:
                    powerUpToCreate = Object.Instantiate(Resources.Load<BasePowerUp>("PowerUps/MaxiSizePowerUp"));
                    break;
            
                case PowerUpType.MinSize:
                    powerUpToCreate = Object.Instantiate(Resources.Load<BasePowerUp>("PowerUps/MiniSizePowerUp"));
                    break;
            
                case PowerUpType.Shield:
                    powerUpToCreate = Object.Instantiate(Resources.Load<BasePowerUp>("PowerUps/ShieldPowerUp"));
                    break;
            }
        
            powerUpToCreate?.Spawn(spawnPosition);
        
            return powerUpToCreate;
        }
    }
}