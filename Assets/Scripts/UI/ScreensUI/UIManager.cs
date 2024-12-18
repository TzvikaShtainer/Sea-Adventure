using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("Container")]
    [SerializeField] private RectTransform screensContainer;
    [SerializeField] private Image bgImage; //not shop image
    
    [Header("MainMenu")]
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI moneyText;
    
    [Header("Shop")]
    [SerializeField] private Transform Shop_InventoryUI;
    
    [Header("Settings")]
    [SerializeField] private Transform settingsMenuUI;
    [SerializeField] private Button returnButton;
    
    [Header("Credits Screen")]
    [SerializeField] private Transform creditsUi;
    [SerializeField] private Button creditsButton;

    private string mainSceneName = "GameScene"; //need to change to level loader
    
    public static event Action OnShopClickedEvent;

    public static event Action OnInventoryClickedEvent;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        
        SetupButtons();

        SetScreen(mainMenuUI);
        
        UpdateMoney(MoneyManager.instance.GetMoneyAmount(), 0);
        
        SoundManager.Instance.SetSceneParameter(1);
        
        SoundManager.Instance.GetP();
    }

    private void SetupButtons()
    {
        //MainMenu btns
        startGameButton.onClick.AddListener(OnStartGameClicked);
        shopButton.onClick.AddListener(OnShopClicked);
        inventoryButton.onClick.AddListener(OnInventoryClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        
        //Settings btns
        returnButton.onClick.AddListener(OnReturnClicked);
        
        //Credits Btn
        creditsButton.onClick.AddListener(OnCreditsClicked);
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

    private void UpdateMoney(int currMoneyAmount, int newMoneyAmount)
    {
        moneyText.SetText(currMoneyAmount.ToString());
    }
    
    private void OnStartGameClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        screensContainer.DOAnchorPos(new Vector3(1500, 0, 0), 0.5f)
            .OnComplete(() => Loader.Load(mainSceneName));
    }

    private void OnShopClicked()
    {
        SetScreen(Shop_InventoryUI);
        
        SoundManager.Instance.PlayClickSound();

        bgImage.enabled = false;
        
        OnShopClickedEvent?.Invoke();
    }
    
    private void OnInventoryClicked()
    {
        SetScreen(Shop_InventoryUI);
        
        SoundManager.Instance.PlayClickSound();

        bgImage.enabled = false;
        
        OnInventoryClickedEvent?.Invoke();
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
    
    private void OnCreditsClicked()
    {
        SoundManager.Instance.PlayClickSound();
        
        SetScreen(creditsUi);
        
        
    }
}
