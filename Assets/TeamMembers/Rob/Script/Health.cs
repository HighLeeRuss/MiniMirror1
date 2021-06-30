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
        Debug.Log("Damaged");
        if (currentHealth <= 0 )
        {
            DeathEvent?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if player is standing in fire
        OnDamage?.Invoke(5f);
    }
}
