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
        float elapsedTime = 0f;

        while (elapsedTime < seconds)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
            
            await Task.Yield();
            
            if (Time.timeScale > 0)
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }
}
