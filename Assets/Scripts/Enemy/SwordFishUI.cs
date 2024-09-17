using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SwordFishUI : MonoBehaviour
{
    [SerializeField] Transform transformImage;
    
    [SerializeField] Sprite swordFishSpriteNoAttackingWhite;
    [SerializeField] Sprite swordFishSpriteAttackingWhite;
    
    [SerializeField] Sprite swordFishSpriteNoAttackingRed;
    [SerializeField] Sprite swordFishSpriteAttackingRed;

    [SerializeField] private float whiteBlinkDuration = 2f;
    [SerializeField] private float redBlinkDuration = 1f; 
    [SerializeField] private float blinkInterval;

    [SerializeField] private Transform fish;

    public event EventHandler<EventArgs> OnUIFinished;

    private void Awake()
    {
        transformImage.GetComponent<Image>().sprite = swordFishSpriteNoAttackingWhite;

        HandleUIBlinking();
    }

    private async void HandleUIBlinking()
    {
        float elapsedTime = 0f;
        
        await Blink(elapsedTime, swordFishSpriteNoAttackingWhite, swordFishSpriteAttackingWhite, whiteBlinkDuration);
        
        elapsedTime = 0f;
        
        await Blink(elapsedTime, swordFishSpriteNoAttackingRed, swordFishSpriteAttackingRed, redBlinkDuration);
        
        transformImage.gameObject.SetActive(false);
        
        OnUIFinished?.Invoke(this, EventArgs.Empty);
    }

    private async Task Blink(float elapsedTime, Sprite firstImage, Sprite secondImage, float blinkDuration)
    {
        while (elapsedTime < blinkDuration)
        {
            transformImage.GetComponent<Image>().sprite = firstImage;
            await Task.Delay((int)(blinkInterval * 1000));
            transformImage.GetComponent<Image>().sprite = secondImage;
            await Task.Delay((int)(blinkInterval * 1000));
            
            elapsedTime += blinkInterval * 2;
        }
    }

    public void SetUIPosition(Vector2 eSpawnPos)
    {
        transformImage.transform.position = eSpawnPos;
    }
}
