using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFishController : MonoBehaviour
{
    [SerializeField] private Transform swordFishVisuals;
    [SerializeField] private Transform swordFishUITransform;
    
    [SerializeField] private SwordFishUI swordFishUI;

    [SerializeField] private bool hasUsed;

    private void Awake()
    {
        swordFishVisuals.gameObject.SetActive(false);
        swordFishUI.gameObject.SetActive(false);
    }
    

    private void OnEnable()
    {
        swordFishUI.OnUIFinished += SwordFishUI_OnUIFinished;

        if (hasUsed)
        {
            ActivateSwordFishAttack();
        }
        
        hasUsed = true;
    }
    
    private void OnDisable()
    {
        swordFishUI.OnUIFinished -= SwordFishUI_OnUIFinished;
        
        swordFishVisuals.gameObject.SetActive(false);
        swordFishUI.gameObject.SetActive(false);
    }

    private void ActivateSwordFishAttack()
    {
        SpawnUI();
    }
    
    private void SpawnUI()
    {
        // Get the screen width
        float screenWidth = Screen.width;
        
        float dynamicYPositionBySwordFish = swordFishVisuals.position.y;
        
        Vector2 screenPosition = new Vector3(screenWidth, 0);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        
        float anchoredXPosition = worldPosition.x;

        Vector2 newPos = new Vector3(anchoredXPosition, dynamicYPositionBySwordFish);
        
        swordFishUITransform.gameObject.SetActive(true);
        
        SoundManager.instance.PlayOneShot(FModEvents.Instance.SwordFishAttack, transform.position);
        
        swordFishUI.SetUIPosition(newPos);
        
        swordFishUI.TriggerUI();
    }

    
    
    private void SwordFishUI_OnUIFinished(object sender, EventArgs e)
    {
        swordFishVisuals.gameObject.SetActive(true);
    }
    

}
