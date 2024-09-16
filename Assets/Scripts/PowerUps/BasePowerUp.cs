using System;
using System.Threading;
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
            if (transform.position.x < -9.5 || transform.position.y < -5)
            {
                gameObject.SetActive(false);
            }
        }

        protected void SetPowerUpTime(float newPowerUpTime)
        {
            powerUpTime = newPowerUpTime;
            playerController = FindObjectOfType<PlayerController>();
        }

        // No async needed here unless you're doing something async
        public virtual async Task Active(CancellationToken cancellationToken)
        {
            await PowerUpHandler(cancellationToken);
        }

        private async Task PowerUpHandler(CancellationToken cancellationToken)
        {
            ActivePowerUp();

            try
            {
                await Task.Delay((int)powerUpTime * 1000, cancellationToken); // Support cancellation
            }
            catch (TaskCanceledException)
            {
                Debug.Log("Power-up was canceled.");
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                DeactivatePowerUp();
            }
        }

        public void DeActive()
        {
            DeactivatePowerUp();
        }
        protected virtual void ActivePowerUp()
        {
            Debug.Log("Base power-up activated");
        }

        protected virtual void DeactivatePowerUp()
        {
            Debug.Log("Base power-up deactivated");
        }

        public void Spawn(Vector2 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
        }
    }
}