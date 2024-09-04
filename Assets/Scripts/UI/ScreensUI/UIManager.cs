using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Container")]
    [SerializeField] private Transform screensContainer;
    
    [Header("MainMenu")]
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    
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
        LoadSceneAsync(mainSceneName);
    }

    private void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    private void OnSettingsClicked()
    {
        SetScreen(settingsMenuUI);
    }
    private void OnExitClicked()
    {
        Application.Quit();
    }
    
    private void OnReturnClicked()
    {
        SetScreen(mainMenuUI);
    }
}
