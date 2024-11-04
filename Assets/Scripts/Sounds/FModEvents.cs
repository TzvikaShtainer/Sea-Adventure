using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    public static FModEvents Instance{get; private set;}
    
    [field: Header("BG Music")]
    [field: SerializeField] public EventReference BgMusic {get; private set;}
    
    [field: Header("Jump Sound")]
    [field: SerializeField] public EventReference JumpSound {get; private set;}
    
    [field: Header("Hitted By Enemy")]
    [field: SerializeField] public EventReference HittedByEnemy {get; private set;}
    
    [field: Header("PowerUp Pickup")]
    [field: SerializeField] public EventReference PowerUpPickup {get; private set;}
    
    [field: Header("Coin Pickup")]
    [field: SerializeField] public EventReference CoinPickup {get; private set;}
    
    [field: Header("Enemy Electrified")]
    [field: SerializeField] public EventReference EnemyElectrified {get; private set;}
    
    [field: Header("Btn Clicked")]
    [field: SerializeField] public EventReference BtnClicked {get; private set;}
    
    [field: Header("SwordFish Attack")]
    [field: SerializeField] public EventReference SwordFishAttack {get; private set;}
    
    [field: Header("Game Over")]
    [field: SerializeField] public EventReference GameOver {get; private set;}
    
    [field: Header("Power Up Ended")]
    [field: SerializeField] public EventReference PowerUpEnded {get; private set;}
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
