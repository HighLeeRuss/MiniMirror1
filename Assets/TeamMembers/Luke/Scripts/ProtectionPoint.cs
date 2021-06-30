using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;

namespace Luke
{
    public class ProtectionPoint : MonoBehaviour
    {
        //References
        public Health health;
        
        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnCollisionEnter(Collision other)
        {
            //fire should hold damage amount
            health.DamageTaken(1);
        }
    }
}
