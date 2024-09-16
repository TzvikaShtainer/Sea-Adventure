using System;
using System.Threading.Tasks;
using UnityEngine;

namespace PowerUps
{
    public class ResizePowerUp : BasePowerUp
    {
        [SerializeField] private float resizeTime;
        [SerializeField] private float resizeSize;
        [SerializeField] private float blinkEffectTime;
        private float originalSize = 0.25f;

        void Start()
        {
            SetPowerUpTime(resizeTime, blinkEffectTime);
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