using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    public static FModEvents instance{get; private set;}
    
    [field: Header("BG Music")]
    [field: SerializeField] public EventReference bgMusic {get; private set;}
    
    [field: Header("Jump Sound")]
    [field: SerializeField] public EventReference jumpSound {get; private set;}
    

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
    }
}
