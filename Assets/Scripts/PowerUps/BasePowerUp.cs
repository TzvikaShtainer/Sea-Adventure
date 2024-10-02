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
                    //await TimeUtils.WaitForGameTime(blinkStartTime, cancellationToken);
                    await Task.Delay((int)(blinkStartTime * 1000), cancellationToken);
                }

                await BlinkEffect(blinkInterval, blinkPowerUpTime, cancellationToken);
                
            }
            catch (OperationCanceledException)
            {
                //Debug.Log("BasePowerUp Power-up was canceled.");
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

            //Debug.Log("Blink effect started.");
            
            while (elapsedTime < duration)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    //Debug.Log("BlinkEffect canceled during loop (before toggle).");
                    SetTransparency(renderer, originalColor.a); // Reset transparency if canceled
                    return; 
                }

                ToggleTransparency(renderer);
                
                try
                {
                    //await TimeUtils.WaitForGameTime(interval, cancellationToken);
                    await Task.Delay((int)(interval * 1000), cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    //Debug.Log("BlinkEffect canceled during wait.");
                    SetTransparency(renderer, originalColor.a); // Reset transparency if canceled
                    return;  // Exit immediately
                }
                
                
                elapsedTime += interval;
                
                cancellationToken.ThrowIfCancellationRequested();
            }

            //Debug.Log("Blink effect completed.");
            
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
            //Debug.Log("Base power-up activated");
        }

        protected virtual void DeactivatePowerUp()
        {
            //Debug.Log("Base power-up deactivated");
        }

        public void Spawn(Vector2 position)
        {
            transform.position = position;
            gameObject.SetActive(true);
        }
    }
}