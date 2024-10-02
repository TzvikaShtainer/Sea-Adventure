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
}
