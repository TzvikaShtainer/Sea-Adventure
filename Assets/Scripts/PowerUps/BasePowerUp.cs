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
        private float blinkPowerUpTime = 3;

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
                float timeBeforeBlink = powerUpTime - blinkPowerUpTime;
                
                await Task.Delay((int)timeBeforeBlink * 1000, cancellationToken); // Support cancellation
                
                await HandleBlinkEffectBeforedeactivate();
                
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

        private async Task HandleBlinkEffectBeforedeactivate()
        {
            SpriteRenderer spriteRenderer = playerController.GetComponentInParent<SpriteRenderer>(); 
            Color originalColor = spriteRenderer.color; 

            float blinkDuration = 3f; // Total blink duration
            float blinkInterval = 0.1f; 
            float elapsedTime = 0f;
            while (elapsedTime < blinkDuration)
            {
                float alpha = (elapsedTime % (blinkInterval * 2) < blinkInterval) ? 0f : 1f;
                
                spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

                await Task.Delay((int)(blinkInterval * 1000));

                elapsedTime += blinkInterval;
            }
            
            spriteRenderer.color = originalColor;
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