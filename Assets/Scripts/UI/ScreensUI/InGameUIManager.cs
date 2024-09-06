using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [Header("In Game menus Container")]
    [SerializeField] private Transform menusContainer;
    
    [Header("Player UI")]
    [SerializeField] private Transform playerUIMenu;
    [SerializeField] private Button pauseButton;
    
    [Header("Pause Menu")]
    [SerializeField] private Transform pauseMenu;
    [SerializeField] private Button pauseContinueButton;
    [SerializeField] private Button pauseRestartButton;
    [SerializeField] private Button pauseReturnToMainMenuButton;
    
    [Header("Death Menu")]
    [SerializeField] private Transform deathMenu;
    [SerializeField] private Button deathRestartButton;
    [SerializeField] private Button deathReturnToMainMenuButton;
    
    private string mainSceneName = "MainMenuScene";
    private bool isPaused = false;
    //private bool isDeath = false;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseClicked);
        
        pauseContinueButton.onClick.AddListener(OnContinueButtonClicked);
        pauseRestartButton.onClick.AddListener(OnRestartButtonClicked);
        pauseReturnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
        
        deathRestartButton.onClick.AddListener(OnRestartButtonClicked);
        deathReturnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);

        SetUpGameScreens();
    }

    private void Start()
    {
        PlayerController.onPlayerDeath += PlayerController_OnPlayerDeath;
    }
    
    private void SetUpGameScreens()
    {
        foreach (Transform child in menusContainer)
        {
            if (child == playerUIMenu)
                continue;
            
            DisableScreen(child);
        }
    }

    private void OnPauseClicked()
    {
        PauseGame();
    }
    
    private void OnContinueButtonClicked()
    {
        DisableScreen(pauseMenu);
        EnableScreen(playerUIMenu);
        Time.timeScale = 1f;         
        isPaused = false;
    }
    
    private void PauseGame()
    {
        EnableScreen(pauseMenu); 
        Time.timeScale = 0f;        
        isPaused = true;
    }
    
    public void OnRestartButtonClicked()
    {
        //isDeath = false;
        Time.timeScale = 1f; 
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
    private void OnReturnToMainMenuButtonClicked()
    {
        //isDeath = false;
        Time.timeScale = 1f; 
        
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

    private void EnableScreen(Transform screenToSet)
    {
        foreach (Transform child in menusContainer)
        {
            if (child == screenToSet) 
                screenToSet.gameObject.SetActive(true);
            else
                DisableScreen(child);
        }
    }
    
    private void DisableScreen(Transform screenToDisable)
    {
        screenToDisable.gameObject.SetActive(false);
    }

    private void PlayerController_OnPlayerDeath()
    {
        //isDeath = true;
        Time.timeScale = 0f;

        foreach (Transform child in menusContainer)
        {
            Debug.Log(child.name);
        }
        
        EnableScreen(deathMenu);
    }
}
