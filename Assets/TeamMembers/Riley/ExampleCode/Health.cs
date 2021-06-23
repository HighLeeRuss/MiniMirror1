using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace RileyMcGowan
{
    public class Health : NetworkBehaviour
    {
        //Private Vars
        [SyncVar]
        private float currentHealth;
        
        //Public Vars
        [Tooltip("Expected 100")]
        public float maxHealth;

        public override void OnStartServer()
        {
            base.OnStartServer();
            ResetHealth();
        }

        public void ResetHealth()
        {
            CurrentHealth = maxHealth;
        }

        public void DoDamage(float damageToDeal)
        {
            CurrentHealth -= damageToDeal;
        }

        public float CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                else if (currentHealth < 0)
                {
                    currentHealth = 0;
                }
            }
        }
    }
}
