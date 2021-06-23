using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;


    public void OnEnable()
    {
        FindObjectOfType<EventManager>().TakeDamage += DamageDealt;
    }

    public void OnDisable()
    {
        FindObjectOfType<EventManager>().TakeDamage -= DamageDealt;    
    }

    public void DamageDealt()
    {
      //take damage   
    }
}
