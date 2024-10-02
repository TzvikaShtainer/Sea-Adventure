using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceEventManager : MonoBehaviour
{
    public List<DistanceEventSO> distanceEvents = new List<DistanceEventSO>();
    [SerializeField] private float timeBetweenEvents = 5;
    
    private float playerDistanceTraveled;
    private HashSet<float> triggeredEvents = new HashSet<float>();


    private void Awake()
    {
        //CreateDefaultDistanceEvents();
    }

    private void Update()
    {
        playerDistanceTraveled = GameManager.instance.distanceTraveled;
        
        foreach (var distanceEvent in distanceEvents)
        {
            if (playerDistanceTraveled > distanceEvent.triggerDistance && !triggeredEvents.Contains(distanceEvent.triggerDistance))
            {
                TriggerEvent(distanceEvent);
                triggeredEvents.Add(distanceEvent.triggerDistance);
            }
        }
    }

    private void TriggerEvent(DistanceEventSO distanceEvent)
    {
        //Stop AllS spawners
        StartCoroutine(HandleAction(distanceEvent));
    }

    private IEnumerator HandleAction(DistanceEventSO distanceEvent)
    {
        SpawnersManager.instance.StopAllSpawners();
        
        yield return new WaitForSeconds(timeBetweenEvents);
        
        // Trigger specific spawner by ID
        if (!string.IsNullOrEmpty(distanceEvent.spawnerID))
        {
            SpawnersManager.instance.TriggerSpawnerByID(distanceEvent.spawnerID, distanceEvent.timeOfEachItemSpawn);
        }
        
        yield return new WaitForSeconds(timeBetweenEvents);
        
        //reset spawners
        StartCoroutine(SpawnersManager.instance.ResumeSpawningAfterDelay(distanceEvent.totalAttackTimeLength));
        
        //return to origin time of spawn
        StartCoroutine(ResetSpawnerSpawnTime(distanceEvent));
    }

    private IEnumerator ResetSpawnerSpawnTime(DistanceEventSO distanceEvent)
    {
        yield return new WaitForSeconds(distanceEvent.itemSpawnTime);
        
        if (!string.IsNullOrEmpty(distanceEvent.spawnerID))
        {
            SpawnersManager.instance.TriggerSpawnerByID(distanceEvent.spawnerID, distanceEvent.originItemSpawnTime);
        }
    }
    
    private void CreateDefaultDistanceEvents()
    {
        float startingDistance = 5000;

        for (int i = 1; i <= 10; i++) 
        {

            //not working for now
            if (i % 3 == 1)  
            {
                CreateSwordFishAttackEvent(startingDistance * i, i);
            }
            
        }
    }

    private void CreateSwordFishAttackEvent(float distance, int i)
    {
        DistanceEventSO newEvent = ScriptableObject.CreateInstance<DistanceEventSO>();
        newEvent.name = "SwordFishAttack";
        newEvent.eventName = "SwordFishAttack";
        newEvent.spawnerID = "SwordFish";
        newEvent.triggerDistance = distance * i;
        newEvent.totalAttackTimeLength = 20;
        newEvent.itemSpawnTime = 5;
        newEvent.originItemSpawnTime = 10;
        newEvent.timeOfEachItemSpawn = 1;
            
        distanceEvents.Add(newEvent);
    }
    
    private void CreatePufferFishAttackEvent(float distance, int i)
    {
        DistanceEventSO newEvent = ScriptableObject.CreateInstance<DistanceEventSO>();
        newEvent.name = "PufferFishAttack";
        newEvent.eventName = "PufferFishAttack";
        newEvent.spawnerID = "PufferFish";
        newEvent.triggerDistance = distance * i;
        newEvent.totalAttackTimeLength = 30;
        newEvent.itemSpawnTime = 5;
        newEvent.originItemSpawnTime = 10;
        newEvent.timeOfEachItemSpawn = 1;
            
        distanceEvents.Add(newEvent);
    }
    
    private void CreateCoinAttackEvent(float distance, int i)
    {
        DistanceEventSO newEvent = ScriptableObject.CreateInstance<DistanceEventSO>();
        newEvent.name = "CoinsAttack";
        newEvent.eventName = "CoinsAttack";
        newEvent.spawnerID = "Coins";
        newEvent.triggerDistance = distance * i;
        newEvent.totalAttackTimeLength = 20;
        newEvent.itemSpawnTime = 5;
        newEvent.originItemSpawnTime = 2;
        newEvent.timeOfEachItemSpawn = 0.3f;
            
        distanceEvents.Add(newEvent);
    }
}
