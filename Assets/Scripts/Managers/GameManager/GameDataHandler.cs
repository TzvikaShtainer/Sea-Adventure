using System;
using DefaultNamespace.GameManager;
using UnityEngine;
using UnityEngine.Android;

public class GameDataHandler : MonoBehaviour
{
    public static GameDataHandler instance;
    
    [SerializeField] GameDataSO gameDataSO;
    //private GameData gameData;
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
        
        SerializeJson();
    }

    private void Start()
    {
        // Check if the WRITE_EXTERNAL_STORAGE permission is already granted
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            // Request the permission at runtime
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }

    public void SerializeJson()
    {
        long startTime = DateTime.Now.Ticks;
        
        //C:\Users\tzvik\AppData\LocalLow\DefaultCompany\SeaAdventure - full path
        if (dataService.SaveData("/JsonGameData.json", gameDataSO, encryptionEnabled))
        {
            saveTime = DateTime.Now.Ticks - startTime;
            Debug.Log("time it took to save the data: "+ saveTime/1000f + " in ms");
            
            startTime = DateTime.Now.Ticks;
            try
            {
                GameDataSO data = dataService.LoadData<GameDataSO>("/JsonGameData.json", encryptionEnabled);
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
        return gameDataSO.MaxDistanceTraveled;
    }
    
    public int GetMoneyAmount()
    {
        return gameDataSO.MoneyAmount;
    }

    public void SetMaxDistanceTraveled(float newValue)
    {
        gameDataSO.MaxDistanceTraveled = newValue;
        SerializeJson();
    }
    
    public void SetMoneyAmount(int newValue)
    {
        gameDataSO.MoneyAmount = newValue;
        SerializeJson();
    }
}
