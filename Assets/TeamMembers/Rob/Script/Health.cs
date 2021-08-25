using System;
using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices.AntiCheatCommon;
using Epic.OnlineServices.Lobby;
using Mirror;
using Rob;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [SyncVar] public float currentHealth;
    public float maxHealth;
    public HealthBar healthBar;


    public override void OnStartServer()
    {
        base.OnStartServer();
        currentHealth = maxHealth;
        healthBar.RpcSetMaxHealth(maxHealth);
    }
    
    public void OnEnable()
     {
         FindObjectOfType<EventManager>().DeathEvent += DeathEvent;
         FindObjectOfType<EventManager>().OnDamageEvent += DamageEventTaken;

     }

     public void OnDisable()
     {
         FindObjectOfType<EventManager>().DeathEvent -= DeathEvent;
         FindObjectOfType<EventManager>().OnDamageEvent -= DamageEventTaken;
     }


     public void DamageEventTaken(float damageAmount)
    {
        if (isServer)
        {
            currentHealth -= damageAmount;
            
            healthBar.RpcSetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                healthBar.RpcSetHealth(currentHealth);
                Debug.Log("Dead");
            }
            Debug.Log("Damaged current health is now " + currentHealth);
            if (currentHealth <= 0)
            {
                FindObjectOfType<EventManager>().CallDeathEvent();
            }
        }
    }

    public void DeathEvent()
    {
        Debug.Log("Died");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<EventManager>().CallTakeDamageEvent();
        }
    }
}
