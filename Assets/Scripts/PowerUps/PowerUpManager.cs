using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpManager : MonoBehaviour
    {
        private CancellationTokenSource _currentPowerUpTokenSource;
        private BasePowerUp _currentPowerUp;

        public async void ActivatePowerUp(BasePowerUp powerUp)
        {
            SoundManager.Instance.PlayOneShot(FModEvents.Instance.PowerUpPickup, transform.position);
            
            if (_currentPowerUp != null)
            {
                DeActivatePowerUp();
            }
            
            _currentPowerUpTokenSource = new CancellationTokenSource();
            _currentPowerUp = powerUp;
            

            try
            {
                _currentPowerUpTokenSource.Token.ThrowIfCancellationRequested();
                
                //Debug.Log($"{powerUp} STARTED.");
                await powerUp.Active(_currentPowerUpTokenSource.Token);
                
                _currentPowerUpTokenSource.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                //Debug.Log($"{powerUp} was canceled.");
                powerUp.DeActive();
            }
            finally
            {
                //Debug.Log($"{_currentPowerUp} current.");
                _currentPowerUp = null;
                _currentPowerUpTokenSource.Dispose();
            }
        }
        public async void DeActivatePowerUp()
        {
            _currentPowerUp.DeActive();
            
            SoundManager.Instance.PlayOneShot(FModEvents.Instance.PowerUpEnded, transform.position);
            
            _currentPowerUpTokenSource.Cancel(); 
            _currentPowerUpTokenSource.Dispose();
                
            _currentPowerUp = null;
        }
        
    }
}