using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpeedManager : MonoBehaviour
{
    public static GlobalSpeedManager Instance { get; private set; }

    [SerializeField] private float baseSpeed; 
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedIncreaseRate; 

    [SerializeField] public static float CurrentSpeed { get; private set; } 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentSpeed = baseSpeed; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Debug.Log(CurrentSpeed);
        CurrentSpeed = Mathf.Min(maxSpeed, CurrentSpeed + speedIncreaseRate * Time.deltaTime);
    }
}
