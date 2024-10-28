using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop_InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform shopUI;
    [SerializeField] private Transform inventoryUI;
    
    [SerializeField] private Button switchButton;
    [SerializeField] private TextMeshProUGUI shopInventoryTitle;

    private bool isShop = true;

    private void Start()
    {
        switchButton.onClick.AddListener(SwitchUI);
        UpdateUI();
    }

    private void SwitchUI()
    {
        isShop = !isShop;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        if (isShop)
        {
            shopUI.gameObject.SetActive(true);
            inventoryUI.gameObject.SetActive(false);
            shopInventoryTitle.text = "Shop"; 
            switchButton.GetComponentInChildren<TextMeshProUGUI>().text = "Inventory";
        }
        else
        {
            shopUI.gameObject.SetActive(false);
            inventoryUI.gameObject.SetActive(true);
            shopInventoryTitle.text = "Inventory"; 
            switchButton.GetComponentInChildren<TextMeshProUGUI>().text = "Shop"; 
        }
    }
}
