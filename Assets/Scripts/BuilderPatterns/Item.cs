using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ISpawn
{
    [SerializeField] private float minYPosToSpawn;
    [SerializeField] private float maxYPosToSpawn;
    
    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
    
    public float GetMinYPosToSpawn()
    {
        return minYPosToSpawn; 
    }
    
    public float GetMaxYPosToSpawn()
    {
        return maxYPosToSpawn; 
    }
}
