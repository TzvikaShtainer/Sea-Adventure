using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    FishingRod,
    SwordFish
}
public class EnemyFactory
{
    public BaseEnemy CreateEnemy(EnemyType enemyType, Vector2 spawnPosition)
    {
        BaseEnemy enemyToCreate = null;

        switch (enemyType)
        {
            case EnemyType.FishingRod:
                enemyToCreate = Object.Instantiate(Resources.Load<BaseEnemy>("FishingRod"));
                break;
            
            case EnemyType.SwordFish:
                enemyToCreate = Object.Instantiate(Resources.Load<BaseEnemy>("SwordFish"));
                break;
        }
        
        enemyToCreate?.Spawn(spawnPosition);
        return enemyToCreate;
    }
}
