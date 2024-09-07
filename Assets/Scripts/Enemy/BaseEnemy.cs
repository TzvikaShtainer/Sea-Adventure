using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public Vector2 MinSpawnPosition { get; private set; }
    public Vector2 MaxSpawnPosition { get; private set; }
    public Vector2 PositionToRemove { get; protected set; } // just until obj pool i think
    
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    private void SetMinMaxPosition(Vector2 newMin, Vector2 newMax)
    {
        MinSpawnPosition = newMin;
        MaxSpawnPosition = newMax;
    }
    
    public void SetSpawnBoundaries(Vector2 newMin, Vector2 newMax)
    {
        SetMinMaxPosition(newMin, newMax);
    }

    public void SetPositionToRemove(Vector2 position)
    {
        PositionToRemove = position;
    }
}
