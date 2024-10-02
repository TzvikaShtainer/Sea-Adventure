using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    public static SpawnersManager instance;
    
    [Header("Enemies Spawners")]
    [SerializeField] Spawner swordFishSpawner;
    [SerializeField] Spawner seaMineSpawner;
    [SerializeField] Spawner fishingRodSpawner;
    [SerializeField] Spawner pufferFishSpawner;
    [SerializeField] Spawner seaUrchinSpawner;
    
    [Header("PowerUps Spawners")]
    [SerializeField] Spawner shieldSpawner;
    [SerializeField] Spawner maxiSpawner;
    [SerializeField] Spawner miniSpawner;
    [SerializeField] Spawner addLifeSpawner;
    
    [Header("Others Spawners")]
    [SerializeField] Spawner coinsSpawner;

    private Dictionary<string, Spawner> spawnersDictionary = new Dictionary<string, Spawner>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            RegisterSpawners();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void RegisterSpawners()
    {
        spawnersDictionary.Add("SwordFish", swordFishSpawner);
        spawnersDictionary.Add("SeaMine", seaMineSpawner);
        spawnersDictionary.Add("FishingRod", fishingRodSpawner);
        spawnersDictionary.Add("PufferFish", pufferFishSpawner);
        spawnersDictionary.Add("SeaUrchin", seaUrchinSpawner);
        spawnersDictionary.Add("Shield", shieldSpawner);
        spawnersDictionary.Add("Maxi", maxiSpawner);
        spawnersDictionary.Add("Mini", miniSpawner);
        spawnersDictionary.Add("AddLife", addLifeSpawner);
        spawnersDictionary.Add("Coins", coinsSpawner);
    }
    
    public void TriggerSpawnerByID(string spawnerID, float spawnTime)
    {
        if (spawnersDictionary.ContainsKey(spawnerID))
        {
            Spawner spawner = spawnersDictionary[spawnerID];
            
            spawner.SetCanSpawn(true);
            spawner.SetSpawnTime(spawnTime);
        }
        else
        {
            Debug.LogWarning($"Spawner with ID '{spawnerID}' not found.");
        }
    }
    
    public void StopAllSpawners()
    {
        foreach (Spawner spawner in spawnersDictionary.Values)
        {
            spawner.SetCanSpawn(false);
        }
    }

    public IEnumerator ResumeSpawningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (Spawner spawner in spawnersDictionary.Values)
        {
            spawner.SetCanSpawn(true);
        }
    }
}
