using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFishController : MonoBehaviour
{
    [SerializeField] private Transform swordFishVisuals;
    [SerializeField] private SwordFishUI swordFishUI;

    private void Start()
    {
        swordFishVisuals.gameObject.SetActive(false);
        swordFishUI.gameObject.SetActive(true);
        
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
        
        swordFishUI.SetUIPosition(newPos);
    }

    private void OnEnable()
    {
        swordFishUI.OnUIFinished += SwordFishUI_OnUIFinished;
    }

    private void OnDisable()
    {
        swordFishUI.OnUIFinished -= SwordFishUI_OnUIFinished;
    }
    
    private void SwordFishUI_OnUIFinished(object sender, EventArgs e)
    {
        swordFishVisuals.gameObject.SetActive(true);
    }
    

}
