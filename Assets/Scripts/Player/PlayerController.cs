using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private PlayerHealthSystem playerHealth;
    [SerializeField] private bool isDamaged;

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isDamaged)
        {
             await HandleDamage();
        }
    }

    private async Task HandleDamage()
    {
        playerHealth.TakeDamage(1); //all enemies do the same damage for now
        isDamaged = true;
        await Task.Delay(1000);
        
        isDamaged = false;
    }
}
