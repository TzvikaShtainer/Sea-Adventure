using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    [SerializeField] bool isCallBack = false;
    
    private void Update()
    {
        if (!isCallBack)
        {
            isCallBack = true;
            
            Loader.LoaderCallback();
        }
        
    }
}
