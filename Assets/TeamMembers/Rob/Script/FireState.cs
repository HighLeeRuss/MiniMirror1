using System;
using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices.AntiCheatServer;
using UnityEngine;
using Rob;

namespace Rob
{


    public class FireState : StateBase
    {
        private Renderer rend;
        private int moistness;
        public StateBase smokeState;

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
            rend.material.SetColor("Color", Color.red);
            
            if (moistness == 0)
            {
                //GetComponent<TileStateManager>().ChangeState(smokeState);
            }
            
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
        
    }
}