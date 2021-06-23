using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public event Action TakeDamage;


    public void Update()
    {
        if (TakeDamage != null)
        {
            TakeDamage();
        }
    }
}
