using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public static BackGroundManager Instance;
    
    [SerializeField] BackgroundScroller[] backgroundScrollersArrayy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeBackGround(Sprite[] newBackgroundArray)
    {
        for (int i = 0; i < backgroundScrollersArrayy.Length; i++)
        {
            backgroundScrollersArrayy[i].SetBackgroundScrollerArray(newBackgroundArray[i]);
        }
    }
}
