using System;
using System.Threading.Tasks;
using UnityEngine;

namespace PowerUps
{
    public class ResizePowerUp : BasePowerUp
    {
        [SerializeField] private float resizeTime;
        [SerializeField] private float resizeSize;
        private float originalSize;

        private void Start()
        {
            SetPowerUpTime(resizeTime);
            originalSize = playerController.GetPlayerSize();
        }

        protected override void ActivePowerUp()
        {
            playerController.SetPlayerSize(resizeSize);
        }

        protected override void DeactivatePowerUp()
        {
            playerController.SetPlayerSize(originalSize);
        }
    }
}