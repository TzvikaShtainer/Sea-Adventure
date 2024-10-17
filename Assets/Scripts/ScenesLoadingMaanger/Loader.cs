using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static string targetScene;

    public static void Load(string targetSceneName)
    {
        targetScene = targetSceneName;
        
        SceneManager.LoadScene("LoadingScene");
    }

    public static void LoaderCallback()
    {
        LoadSceneAsync(targetScene);
    }
    
    private static async Task LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;  

        // Wait until the scene is fully loaded (progress reaches 90%)
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            
            await Task.Yield();
        }
    }
}
