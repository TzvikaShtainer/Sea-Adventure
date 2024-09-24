using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public static class TimeUtils
{
    public static async Task WaitForGameTime(float seconds)
    {
        float elapsedTime = 0f;

        while (elapsedTime < seconds)
        {
            await Task.Yield();
            
            if (Time.timeScale > 0)
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }
    
    public static async Task WaitForGameTime(float seconds, CancellationToken cancellationToken)
    {
        //Debug.Log("power up time started");
        
        float elapsedTime = 0f;

        while (elapsedTime < seconds)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            await Task.Yield();
            
            if (Time.timeScale > 0)
            {
                elapsedTime += Time.deltaTime;
            }
            
            cancellationToken.ThrowIfCancellationRequested();
        }
        
        //Debug.Log("power up time ended");
    }
}
