using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public static Testing instance{get; private set;}
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //Debug.Log(gameObject.name + " is set as the singleton instance.");
        }
        else
        {
            //Debug.Log(gameObject.name + " is being destroyed because a singleton instance already exists.");
            Destroy(gameObject);
        }
    }
}
