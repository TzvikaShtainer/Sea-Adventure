using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonDataService : IDataService
{
    public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
    {
        //string path = Application.persistentDataPath + RelativePath;
        string path = Path.Combine(Application.persistentDataPath, RelativePath);
        
        try
        {
            Debug.Log($"Saving file to: {path}");
            
            if (File.Exists(path))
            {
                Debug.Log("Data Exists. Deleting old file and writing a new one");
                File.Delete(path);
            }
            else
            {
                Debug.Log("Writing file for the first time");
            }

            // using FileStream stream = File.Create(path); //open stream
            // stream.Close(); //close 
            // File.WriteAllText(path, JsonConvert.SerializeObject(Data)); //write new data
            
            File.WriteAllText(path, JsonConvert.SerializeObject(Data));
            return true;
        }
        catch (Exception e)
        {
            Debug.Log($"Unable to save data due to: {e.Message} {e.StackTrace}");
            return false;
        }
    }

    public T LoadData<T>(string RelativePath, bool Encrypted)
    {
        //string path = Application.persistentDataPath + RelativePath;
        string path = Path.Combine(Application.persistentDataPath, RelativePath);

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load data due to file doesn't exist: {path}");
            throw new FileNotFoundException($"{path} does not exist");
        }

        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed To Load Data Due To : {e.Message} {e.StackTrace}");
            throw e;
        }
    }
}
