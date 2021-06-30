using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{



    public class EventManager : MonoBehaviour
    {
        public event Action DeathEvent;
        
        public delegate void TakeDamageEvent(float damageAmount);
        public event TakeDamageEvent OnDamageEvent;


        public void CallDeathEvent()
        {
            DeathEvent?.Invoke();
            Debug.Log("died");
        }

        public void CallTakeDamageEvent()
        {
            OnDamageEvent?.Invoke(1f);
            Debug.Log("dealt Damage ");
        }
    }
}
