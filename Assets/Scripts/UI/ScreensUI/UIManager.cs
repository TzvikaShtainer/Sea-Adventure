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
    
    [Header("MainMenu")]
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Button storeButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    
    [Header("Store")]
    [SerializeField] private Transform storeUI;
    [SerializeField] private Button storeReturnButton;
    
    [Header("Settings")]
    [SerializeField] private Transform settingsMenuUI;
    [SerializeField] private Button returnButton;

    private string mainSceneName = "GameScene"; //need to change to level loader

    private void Start()
    {
        SetupButtons();

        SetScreen(mainMenuUI);
    }

    private void SetupButtons()
    {
        //MainMenu btns
        startGameButton.onClick.AddListener(OnStartGameClicked);
        storeButton.onClick.AddListener(OnStoreClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        
        //Settings btns
        returnButton.onClick.AddListener(OnReturnClicked);
        
        //Store Btns
        storeReturnButton.onClick.AddListener(OnReturnClicked);
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

    // private void LoadSceneAsync(string sceneName)
    // {
    //     StartCoroutine(LoadSceneCoroutine(sceneName));
    // }
    //
    // private IEnumerator LoadSceneCoroutine(string sceneName)
    // {
    //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
    //     while (!asyncLoad.isDone)
    //     {
    //         yield return null;
    //     }
    // }

    private void OnStoreClicked()
    {
        SetScreen(storeUI);
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
    
    private void OnReturnClicked()
    {
        SetScreen(mainMenuUI);
        
        SoundManager.Instance.PlayClickSound();
    }
}
