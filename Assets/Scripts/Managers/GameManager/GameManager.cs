using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using EventBus = DefaultNamespace.EventBus;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public float distanceTraveled {get; private set; }
    
    [SerializeField] private float maxDistanceTraveled;
    [SerializeField] private float distanceMultiplier;
    [SerializeField] private float accelerationRate;
    
    

    [SerializeField] private GameDataSO _gameDataSo;
    
    public delegate void OnMaxDistanceChanged(float maxDistanceTraveled);
    public static event OnMaxDistanceChanged onMaxDistanceChanged;
    
    public delegate void OnDistanceReached(float maxDistanceTraveled);
    public static event OnDistanceReached onDistanceReached;


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

    private void OnEnable()
    {
        PlayerHealthSystem.onDeath += PlayerHealthSystem_OnDeath;
    }

    private void OnDisable()
    {
        PlayerHealthSystem.onDeath -= PlayerHealthSystem_OnDeath;
    }

    private void Update()
    {
        HandleIncreasingDistance();
    }

    private void HandleIncreasingDistance()
    {
        distanceMultiplier += accelerationRate * Time.deltaTime;
        
        
        distanceTraveled += Time.deltaTime * distanceMultiplier;
        
        EventBus.DistanceChanged(distanceTraveled);
    }
    
    private void PlayerHealthSystem_OnDeath()
    {
        SaveMaxDistanceTraveled();

        onMaxDistanceChanged?.Invoke(maxDistanceTraveled);
    }

    private void SaveMaxDistanceTraveled()
    {
        if (distanceTraveled > _gameDataSo.MaxDistanceTraveled)
        {
            _gameDataSo.MaxDistanceTraveled = distanceTraveled;
        }
    }

    public float LoadMaxDistance()
    {
        return _gameDataSo.MaxDistanceTraveled;
    }
}
