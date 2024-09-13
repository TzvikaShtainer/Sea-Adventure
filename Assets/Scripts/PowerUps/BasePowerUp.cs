using System;
using System.Threading.Tasks;
using UnityEngine;

namespace PowerUps
{
    public abstract class BasePowerUp : MonoBehaviour, ISpawn
    {
        [SerializeField] protected PlayerController playerController;
        private float powerUpTime = 0;

        private void Update()
        {
            if (transform.position.x < -9.5 || transform.position.y < -5) //just for now
            {
                gameObject.SetActive(false);
                //Destroy(gameObject); 
            }
        }

        protected void SetPowerUpTime(float newPowerUpTime)
        {
            powerUpTime = newPowerUpTime;
            playerController = FindObjectOfType<PlayerController>();
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


        public void Spawn(Vector2 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
        }
    }
}