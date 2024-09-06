using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private float maxDistanceTraveled;
    [SerializeField] private float distanceTraveled;
    [SerializeField] private float distanceMultiplier;
    [SerializeField] private float accelerationRate;
    
    public delegate void OnDistanceChanged(float distanceTraveled);
    public static event OnDistanceChanged onDistanceChanged;
    
    public delegate void OnMaxDistanceChanged(float maxDistanceTraveled);
    public static event OnMaxDistanceChanged onMaxDistanceChanged;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        PlayerController.onPlayerDeath += PlayerController_OnPlayerDeath;
    }

    private void Update()
    {
        HandleIncreasingDistance();
    }

    private void HandleIncreasingDistance() // change to events
    {
        distanceMultiplier += accelerationRate * Time.deltaTime;
        
        distanceTraveled += Time.deltaTime * distanceMultiplier;
        
        onDistanceChanged?.Invoke(distanceTraveled);
    }
    
    private void PlayerController_OnPlayerDeath()
    {
        maxDistanceTraveled = distanceTraveled;
        
        
    }

    public float GetMaxDistance()
    {
        return maxDistanceTraveled;
    }
}
