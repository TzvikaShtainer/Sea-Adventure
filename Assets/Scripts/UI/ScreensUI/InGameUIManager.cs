using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [Header("In Game menus Container")]
    [SerializeField] private Transform menusContainer;
    
    [Header("Player UI")]
    [SerializeField] private Transform playerUIMenu;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI maxDistanceText;
    [SerializeField] private Button pauseButton;
    
    [Header("Pause Menu")]
    [SerializeField] private Transform pauseMenu;
    [SerializeField] private Button pauseContinueButton;
    [SerializeField] private Button pauseRestartButton;
    [SerializeField] private Button pauseSoundsButton;
    [SerializeField] private Button pauseReturnToMainMenuButton;
    
    [Header("Death Menu")]
    [SerializeField] private Transform deathMenu;
    [SerializeField] private Button deathRestartButton;
    [SerializeField] private Button deathReturnToMainMenuButton;
    [SerializeField] private TextMeshProUGUI endGameDistanceText;
    
    [Header("Tutorial Menu")]
    [SerializeField] private Transform tutorialMenu;
    
    [Header("Touch")]
    [SerializeField] private Transform touchUI;
    
    [Header("Sounds")]
    [SerializeField] private Transform soundsMenu;
    [SerializeField] private Button soundsReturnButton;
    
    private string mainSceneName = "MainMenuScene";
    private bool isPaused;
    //private bool isDeath = false;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseClicked);
        
        pauseContinueButton.onClick.AddListener(OnContinueButtonClicked);
        pauseRestartButton.onClick.AddListener(OnRestartButtonClicked);
        pauseReturnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
        pauseSoundsButton.onClick.AddListener(OnSoundsButtonClicked);
        
        deathRestartButton.onClick.AddListener(OnRestartButtonClicked);
        deathReturnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
        
        soundsReturnButton.onClick.AddListener(OnSoundsReturnButtonClicked);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        SetUpGameScreens();
    }

    private void OnEnable()
    {
        PlayerHealthSystem.onDeath += PlayerHealthSystem_OnDeath;
        
        //GameManager.onDistanceChanged += GameManager_OnDistanceChanged;
        EventBus.onDistanceChanged += GameManager_OnDistanceChanged;
        GameManager.onMaxDistanceChanged += GameManager_OnMaxDistanceChanged;
    }

    private void OnDisable()
    {
        PlayerHealthSystem.onDeath -= PlayerHealthSystem_OnDeath;
        
        //GameManager.onDistanceChanged -= GameManager_OnDistanceChanged;
        GameManager.onMaxDistanceChanged -= GameManager_OnMaxDistanceChanged;
        GameManager.onMaxDistanceChanged -= GameManager_OnMaxDistanceChanged;
    }

    private void SetUpGameScreens()
    {
        DisableAllScreens();

        if (!CheckTutorialCompleted())
        {
            ShowTutorial();
        }
        
        StartGame();
    }
    
    private void DisableAllScreens()
    {
        foreach (Transform child in menusContainer)
        {
            if (child == playerUIMenu)
                continue;
            
            DisableScreen(child);
        }
    }
    
    private bool CheckTutorialCompleted()
    {
        return GameDataHandler.instance.GetTutorialCompleted();
    }

    private void ShowTutorial()
    {
        tutorialMenu.gameObject.SetActive(true);
        
        Time.timeScale = 0f;
    }
    
    private void StartGame()
    {
        UpdateMaxDistanceText(GameManager.instance.LoadMaxDistance());

        touchUI.gameObject.SetActive(true);
    }

    private void OnPauseClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        PauseGame();
    }
    
    private void OnContinueButtonClicked()
    {
        SoundManager.Instance.PlayClickSound();

        if (!CheckTutorialCompleted())
        {
            DisableScreen(pauseMenu);
            EnableScreen(tutorialMenu);
        }
        else
        {
            DisableScreen(pauseMenu);
            Time.timeScale = 1f;         
            isPaused = false;
        }
        
        playerUIMenu.gameObject.SetActive(true);
        touchUI.gameObject.SetActive(true);
        
    }
    
    private void PauseGame()
    {
        EnableScreen(pauseMenu); 
        Time.timeScale = 0f;        
        isPaused = true;
    }
    
    public void OnRestartButtonClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        Time.timeScale = 1f; 
        
        LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
    private void OnReturnToMainMenuButtonClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        LoadSceneAsync(mainSceneName);
        
        //Time.timeScale = 1f;
    }
    
    private void OnSoundsButtonClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        EnableScreen(soundsMenu); 
    }
    
    private void OnSoundsReturnButtonClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        EnableScreen(pauseMenu); 
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

    private void PlayerHealthSystem_OnDeath()
    {
        Time.timeScale = 0f;
        
        EnableScreen(deathMenu);
        
        DisableScreen(touchUI);
    }
    
    private void GameManager_OnDistanceChanged(float distanceTraveled)
    {
        distanceText.text =  Mathf.FloorToInt(distanceTraveled).ToString() + " M";
        
        endGameDistanceText.text = "DISTANCE:  \n" + Mathf.FloorToInt(distanceTraveled).ToString() + "M";
    }
    
    private void GameManager_OnMaxDistanceChanged(float newMaxDistanceTraveled)
    {
        UpdateMaxDistanceText(newMaxDistanceTraveled);
    }

    private void UpdateMaxDistanceText(float newMaxDistanceTraveled)
    {
        maxDistanceText.text = "BEST: " + Mathf.FloorToInt(newMaxDistanceTraveled).ToString() + "M";
    }
}
