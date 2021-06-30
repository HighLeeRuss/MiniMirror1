using System;
using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices.AntiCheatCommon;
using Epic.OnlineServices.Lobby;
using Rob;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float damageAmount;
    
    public event Action DeathEvent;


    

    public void OnEnable()
    {
        FindObjectOfType<FireState>().TakeDamageEvent += TakeDamage;
    }

    public void OnDisable()
    {
        FindObjectOfType<FireState>().TakeDamageEvent -= TakeDamage;
    }
    
    
    public void TakeDamage()
    {
        health -= damageAmount;
        Debug.Log("Damaged");
        if (health <= 0 )
        {
            DeathEvent?.Invoke();
        }
        
    }
}
