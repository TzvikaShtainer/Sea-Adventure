using System;
using System.Threading.Tasks;
using UnityEngine;

namespace PowerUps
{
    public abstract class BasePowerUp : MonoBehaviour
    {
        [SerializeField] protected PlayerController playerController;
        private float powerUpTime;

        protected void SetPowerUpTime(float newPowerUpTime)
        {
            powerUpTime = newPowerUpTime;
        }
        public virtual async Task Active()
        {
           await PowerUpHandler();
        }
        
        private async Task PowerUpHandler()
        {
            ActivePowerUp();
            
            await Task.Delay((int)powerUpTime * 1000);
            
            DeactivatePowerUp();
        }

        protected virtual void ActivePowerUp()
        {
            Debug.Log("base power up activated");
        }

        protected virtual void DeactivatePowerUp()
        {
            Debug.Log("base power up Deactivate");
        }

        
    }
}