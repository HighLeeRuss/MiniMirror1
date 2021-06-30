using System;
using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices.AntiCheatCommon;
using Epic.OnlineServices.Lobby;
using Rob;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public event Action DeathEvent;
    public delegate void TakeDamage(float damageAmount);
    public event TakeDamage OnDamage;


    public void DamageTaken(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        
        Debug.Log("Damaged current health is now " + currentHealth);
        
        if (currentHealth <= 0 )
        {
            DeathEvent?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnDamage?.Invoke(1f);
    }

    public void Death()
    {
        Debug.Log("Died");
    }
}
