using System;
using DefaultNamespace.GameManager;
using UnityEngine;
using UnityEngine.Android;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler instance;
    
    //[SerializeField] GameDataSO gameDataSO;
    private GameData gameData;
    private IDataService dataService = new JsonDataService();
    private bool encryptionEnabled;
    private long saveTime;
    private long loadTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGameData();
    }

    private void Start()
    {
        // Check if the WRITE_EXTERNAL_STORAGE permission is already granted
        //if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        //{
            // Request the permission at runtime
        //    Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        //}
    }
    
    public void LoadGameData()
    {
        long startTime = DateTime.Now.Ticks;

        try
        {
            // Attempt to load saved data
            gameData = dataService.LoadData<GameData>("/JsonGameData.json", encryptionEnabled);

            if (gameData == null)
            {
                Debug.Log("No saved game data found. Initializing with default values.");
                gameData = new GameData(); // Initialize with default values if no data is found
            }

            loadTime = DateTime.Now.Ticks - startTime;
            //Debug.Log("Game data loaded. Time: " + loadTime / 1000f + " ms");
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading game data: " + e.Message);
            gameData = new GameData(); // Initialize with default values on failure
        }
    }


    public void SaveGameData()
    {
        long startTime = DateTime.Now.Ticks;
        
        //C:\Users\tzvik\AppData\LocalLow\DefaultCompany\SeaAdventure - full path
        if (dataService.SaveData("/JsonGameData.json", gameData, encryptionEnabled))
        {
            saveTime = DateTime.Now.Ticks - startTime;
            Debug.Log("time it took to save the data: "+ saveTime/1000f + " in ms");
            
            startTime = DateTime.Now.Ticks;
            try
            {
                gameData = dataService.LoadData<GameData>("/JsonGameData.json", encryptionEnabled);
                loadTime = DateTime.Now.Ticks - startTime;
                Debug.Log("time it took to load the data: "+ saveTime/1000f + " in ms");
            }
            catch (Exception e)
            {
                Debug.LogError($"could not read file! show something on the ui here!");
            }
        }
        else
        {
            Debug.Log("Could not save data file! show something on th UI about it!");
        }
    }

    public float GetMaxDistanceTraveled()
    {
        return gameData.MaxDistanceTraveled;
    }
    
    public void SetMaxDistanceTraveled(float newValue)
    {
        gameData.MaxDistanceTraveled = newValue;
        SaveGameData();
    }
    
    public int GetMoneyAmount()
    {
        return gameData.MoneyAmount;
    }
    
    public void SetMoneyAmount(int newValue)
    {
        gameData.MoneyAmount = newValue;
        SaveGameData();
    }

    public bool GetTutorialCompleted()
    {
        return gameData.tutorialCompleted;
    }

    public void SetTutorialCompleted(bool newValue)
    {
        gameData.tutorialCompleted = newValue;
        SaveGameData();
    }
}
