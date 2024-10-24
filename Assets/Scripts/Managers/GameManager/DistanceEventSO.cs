using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Distance Event", menuName = "Game/Distance Event")]
public class DistanceEventSO : ScriptableObject
{
    public string eventName;
    public string spawnerID; 
    public float triggerDistance;
    public int totalAttackTimeLength;
    public float itemSpawnTime;
    public float originItemSpawnTime;
    public float timeOfEachItemSpawn;
    
}
