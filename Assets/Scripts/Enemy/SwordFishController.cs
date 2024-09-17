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
        Vector2 newUIPos = new Vector2(8.8f, swordFishVisuals.position.y);
        
        swordFishUI.SetUIPosition(newUIPos);
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
