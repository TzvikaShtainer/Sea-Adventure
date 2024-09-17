using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    FishingRod,
    SwordFish,
    SeaUrchin,
    SeaMine
}
public class EnemyFactory
{
    public BaseEnemy CreateEnemy(EnemyType enemyType, Vector2 spawnPosition)
    {
        BaseEnemy enemyToCreate = null;

        switch (enemyType)
        {
            case EnemyType.FishingRod:
                enemyToCreate = Object.Instantiate(Resources.Load<BaseEnemy>("Enemies/FishingRod"));
                break;
            
            case EnemyType.SwordFish:
                enemyToCreate = Object.Instantiate(Resources.Load<BaseEnemy>("Enemies/SwordFishWithUI"));
                break;
            
            case EnemyType.SeaUrchin:
                enemyToCreate = Object.Instantiate(Resources.Load<BaseEnemy>("Enemies/SeaUrchin"));
                break;
            
            case EnemyType.SeaMine:
                enemyToCreate = Object.Instantiate(Resources.Load<BaseEnemy>("Enemies/SeaMine"));
                break;
        }
        
        enemyToCreate?.Spawn(spawnPosition);
        
        return enemyToCreate;
    }
}
