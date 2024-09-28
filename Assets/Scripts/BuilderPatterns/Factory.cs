using PowerUps;
using UnityEngine;

public enum ItemType
{
    FishingRod,
    SwordFish,
    SeaUrchin,
    SeaMine,
    AddLife,
    MaxSize,
    MinSize,
    Shield,
    Coin
}

public class Factory
{
    public Item CreateItem(ItemType itemType, Vector2 spawnPosition)
    {
        Item itemToCreate = null;

        switch (itemType)
        {
            //enemies
            case ItemType.FishingRod:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("Enemies/FishingRod"));
                break;
            
            case ItemType.SwordFish:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("Enemies/SwordFishWithUI"));
                break;
            
            case ItemType.SeaUrchin:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("Enemies/SeaUrchin"));
                break;
            
            case ItemType.SeaMine:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("Enemies/SeaMine"));
                break;
            
            //powerups
            case ItemType.AddLife:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("PowerUps/AddLifePowerUp"));
                break;
            
            case ItemType.MaxSize:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("PowerUps/MaxiSizePowerUp"));
                break;
            
            case ItemType.MinSize:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("PowerUps/MiniSizePowerUp"));
                break;
            
            case ItemType.Shield:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("PowerUps/ShieldPowerUp"));
                break;
            
            //others
            case ItemType.Coin:
                itemToCreate = Object.Instantiate(Resources.Load<Item>("Others/Coin"));
                break;
        }
        
        itemToCreate?.Spawn(spawnPosition);
        
        return itemToCreate;
    }
}
