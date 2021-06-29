using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;

namespace Rob
{


    public class FireState : StateBase
    {
        private Renderer rend;

        public void OnEnable()
        {
            FindObjectOfType<Health>().TakeDamage += Damage;
        }

        public void OnDisable()
        {
            FindObjectOfType<Health>().TakeDamage -= Damage;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("executing");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public void Damage()
        {
            //do damage things
            Debug.Log("Damaged, ouch");
        }

        public void OnCollisionEnter(Collision col)
        {
            //is on fire
            OnFire();
            
        }

        public void OnFire()
        {
            rend.material.SetColor("Color", Color.red);
        }
    }
}