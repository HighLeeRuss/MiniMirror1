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
        private bool isHealActive;
        
        //Public Vars
        [Tooltip("Expected 100")]
        public float maxHealth;
        public bool canHeal;

        public override void OnStartServer()
        {
            base.OnStartServer();
            isHealActive = false;
            ResetHealth();
        }

        public void ResetHealth()
        {
            CurrentHealth = maxHealth;
        }

        public void DoDamage(float damageToDeal)
        {
            if (isHealActive == true && canHeal == true)
            {
                StopCoroutine(HealOverTime());
            }
            CurrentHealth -= damageToDeal;
            if (isHealActive == false && canHeal == true)
            {
                StartCoroutine(HealOverTime());
            }
        }

        IEnumerator HealOverTime()
        {
            isHealActive = true;
            yield return new WaitForSeconds(10);
            while (CurrentHealth < maxHealth)
            {
                CurrentHealth += 1;
                yield return new WaitForSeconds(.5f);
            }
            isHealActive = false;
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
