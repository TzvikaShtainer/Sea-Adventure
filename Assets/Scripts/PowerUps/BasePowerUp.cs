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
        private float blinkPowerUpTime = 0;
        [SerializeField] Renderer renderer;
        
        private void Update()
        {
            if (transform.position.x < -9.5 || transform.position.y < -5)
            {
                gameObject.SetActive(false);
            }
        }

        protected void SetPowerUpTime(float newPowerUpTime, float newBlinkPowerUpTime)
        {
            powerUpTime = newPowerUpTime;
            blinkPowerUpTime = newBlinkPowerUpTime;
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

            float blinkStartTime = powerUpTime - 3f;
            float blinkInterval = 0.3f;

            try
            {
                if (blinkStartTime > 0)
                {
                    await Task.Delay((int)(blinkStartTime * 1000), cancellationToken);
                }

                await BlinkEffect(blinkInterval, blinkPowerUpTime, cancellationToken);

                //await Task.Delay((int)(3f * 1000), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                Debug.Log("BasePowerUp Power-up was canceled.");
                
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                DeactivatePowerUp();
            }
        }

        private async Task BlinkEffect(float interval, float duration, CancellationToken cancellationToken)
        {
            float elapsedTime = 0f;
            renderer = playerController.GetSprite();
            Color originalColor = renderer.material.color;

            while (elapsedTime < duration)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    SetTransparency(renderer, originalColor.a); // Reset transparency if canceled
                    return; // Stop the blinking immediately
                }

                ToggleTransparency(renderer);
                await Task.Delay((int)(interval * 1000), cancellationToken);
                elapsedTime += interval;
            }

            SetTransparency(renderer, originalColor.a); // Ensure transparency reset after blinking
        }

        private void ToggleTransparency(Renderer renderer)
        {
            Color color = renderer.material.color;
            color.a = color.a == 1f ? 0.5f : 1f; // Toggle transparency
            renderer.material.color = color;
        }

        private void SetTransparency(Renderer renderer, float alpha)
        {
            Color color = renderer.material.color;
            color.a = alpha;
            renderer.material.color = color;
        }
        
       // playerController.GetComponentInParent<Renderer>();
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