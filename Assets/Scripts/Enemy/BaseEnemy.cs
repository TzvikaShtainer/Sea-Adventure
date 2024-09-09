using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy
{
    public delegate void OnEnemyDead();
    public static event OnEnemyDead onEnemyDead;
    
    [SerializeField] private float minYPosToSpawn;
    [SerializeField] private float maxYPosToSpawn;
    
    private void Update()
    {
        if (transform.position.x < -9.5) //just for now
        {
            gameObject.SetActive(false);
                
            onEnemyDead?.Invoke();
        }
    }
    
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
