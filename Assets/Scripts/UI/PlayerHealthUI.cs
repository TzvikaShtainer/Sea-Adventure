using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Transform healthIconsContainer;
    [SerializeField] private Transform iconImage;
    private void OnEnable()
    {
        PlayerHealthSystem.onHealthChange += PlayerHealthSystem_OnHealthChange;
    }

    private void OnDisable()
    {
        PlayerHealthSystem.onHealthChange -= PlayerHealthSystem_OnHealthChange;
    }

    private void PlayerHealthSystem_OnHealthChange(float health, float amt, float maxhealth)
    {
        UpdateVisuals(health);
    }


    private void UpdateVisuals(float health)
    {
        foreach (Transform child in healthIconsContainer)
        {
            if (child == iconImage)
                continue;
            
            Destroy(child.gameObject);
        }

        for (int i = 1; i < health; i++)
        {
            Transform newDeliveryIcon = Instantiate(iconImage, healthIconsContainer);
            newDeliveryIcon.gameObject.SetActive(true);
        }

    }
}
