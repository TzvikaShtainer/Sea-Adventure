using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameDataSO : ScriptableObject
{
    public float MaxDistanceTraveled; 
    public int MoneyAmount; 
}