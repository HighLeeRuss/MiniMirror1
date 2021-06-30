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
        
        //Events
        public event Action ProtectionPointDestroyedEvent;
        
        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //private void OnEnable()
        //{
            //health.DeathEvent += DestroyProtectionPoint;
        //}

        //private void OnDisable()
        //{
            //health.DeathEvent -= DestroyProtectionPoint;
        //}

        //public void DestroyProtectionPoint()
        //{
            //ProtectionPointDestroyedEvent?.Invoke();
            //Destroy(this);
        //}
    }
}
