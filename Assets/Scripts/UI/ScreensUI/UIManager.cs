using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Container")]
    [SerializeField] private RectTransform screensContainer;
    [SerializeField] private Image bgImage; //not shop image
    
    [Header("MainMenu")]
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    
    [Header("Shop")]
    [SerializeField] private Transform shopUI;
    
    [Header("Settings")]
    [SerializeField] private Transform settingsMenuUI;
    [SerializeField] private Button returnButton;

    private string mainSceneName = "GameScene"; //need to change to level loader

    private void Start()
    {
        Time.timeScale = 1f;
        
        SetupButtons();

        SetScreen(mainMenuUI);
    }

    private void SetupButtons()
    {
        //MainMenu btns
        startGameButton.onClick.AddListener(OnStartGameClicked);
        shopButton.onClick.AddListener(OnShopClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        
        //Settings btns
        returnButton.onClick.AddListener(OnReturnClicked);
    }

    private void SetScreen(Transform screenToSet)
    {
        foreach (Transform child in screensContainer)
        {
            if (child == screenToSet) 
                screenToSet.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
    }

    private void OnStartGameClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        screensContainer.DOAnchorPos(new Vector3(1500, 0, 0), 0.5f)
            .OnComplete(() => Loader.Load(mainSceneName));
    }

    private void OnShopClicked()
    {
        SetScreen(shopUI);
        
        SoundManager.Instance.PlayClickSound();

        bgImage.enabled = false;
    }
    private void OnSettingsClicked()
    {
        SetScreen(settingsMenuUI);
        
        SoundManager.Instance.PlayClickSound();
    }
    private void OnExitClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        Application.Quit();
    }
    
    public void OnReturnClicked()
    {
        SetScreen(mainMenuUI);
        
        SoundManager.Instance.PlayClickSound();
        
        bgImage.enabled = true;
    }
}
