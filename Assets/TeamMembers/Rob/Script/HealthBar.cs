using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using Rob;

namespace Rob
{
    public class HealthBar : NetworkBehaviour
    {
        public Slider slider;
        
        [ClientRpc]
        public void RpcSetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
        
        [ClientRpc]
       public void RpcSetHealth(float health)
       {
           slider.value = health;
       }
    }
}