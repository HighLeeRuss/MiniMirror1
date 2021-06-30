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


    public void OnEnable()
    {
        FindObjectOfType<EventManager>().DeathEvent += Death;
        FindObjectOfType<EventManager>().OnDamageEvent += DamageEventTaken;

    }

    public void OnDisable()
    {
        FindObjectOfType<EventManager>().DeathEvent -= Death;
        FindObjectOfType<EventManager>().OnDamageEvent -= DamageEventTaken;
    }


    public void DamageEventTaken(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead");
        }
        Debug.Log("Damaged current health is now " + currentHealth);
        if (currentHealth <= 0)
        {
            GetComponent<EventManager>().CallDeathEvent();
            
        }
        
    }

    public void Death()
    {
        Debug.Log("Died");
    }




}
