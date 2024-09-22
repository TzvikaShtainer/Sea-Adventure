using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    [field: Header("Jump Sound")]
    [field: SerializeField] public EventReference jumpSound {get; private set;}
    
    public static FModEvents instance{get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("FModEvents instance is null");
        }
        
        instance = this;
    }
}
