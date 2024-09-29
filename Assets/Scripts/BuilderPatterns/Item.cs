using System;
using System.Collections;
using System.Collections.Generic;
using BuilderPatterns;
using UnityEngine;

public class Item : MonoBehaviour, ISpawn
{
    [SerializeField] private float minYPosToSpawn;
    [SerializeField] private float maxYPosToSpawn;

    private readonly float afterPlayerPosToDisapear = -15;
    private ItemType itemType;

    private void Start()
    {
        itemType = GetComponentInParent<MoveToPlayer>().GetItemType();
    }

    private void Update()
    {
        if(transform.position.x < afterPlayerPosToDisapear)
        {
            PoolManager.Instance.ReturnItemToPool(itemType, this);
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
