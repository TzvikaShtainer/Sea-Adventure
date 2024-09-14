﻿using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpManager : MonoBehaviour
    {
        private CancellationTokenSource _currentPowerUpTokenSource;
        private BasePowerUp _currentPowerUp;

        public async void ActivatePowerUp(BasePowerUp powerUp)
        {
            if (_currentPowerUp != null)
            {
                _currentPowerUp.DeActive();
                
                _currentPowerUpTokenSource.Cancel(); 
                _currentPowerUpTokenSource.Dispose(); 
                _currentPowerUp = null; 
            }
            
            _currentPowerUpTokenSource = new CancellationTokenSource();
            _currentPowerUp = powerUp;

            try
            {
                await powerUp.Active(_currentPowerUpTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                Debug.Log($"{powerUp} was canceled.");
            }
            finally
            {
                _currentPowerUp = null;
                _currentPowerUpTokenSource.Dispose();
            }
        }
        
        public void CancelCurrentPowerUp()
        {
            if (_currentPowerUp != null)
            {
                _currentPowerUpTokenSource.Cancel();
                _currentPowerUpTokenSource.Dispose();
                _currentPowerUp = null;
            }
        }
    }
}