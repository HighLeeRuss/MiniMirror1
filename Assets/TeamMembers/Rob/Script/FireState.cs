using System;
using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices.AntiCheatServer;
using Epic.OnlineServices.Lobby;
using Mirror.Examples.Pong;
using UnityEngine;
using Rob;

namespace Rob
{


    public class FireState : StateBase
    {
        private Renderer rend;
        public StateBase smokeState;
        public GameObject manageState;
        private int moistness;
        public event Action TakeDamageEvent;

        public void OnEnable()
        {
            FindObjectOfType<Health>().DeathEvent += Death;
        }

        public void OnDisable()
        {
            FindObjectOfType<Health>().DeathEvent -= Death;
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


      private void OnTriggerEnter(Collider col)
      
      {
          TakeDamageEvent?.Invoke();
      }

        public void Death()
        {
           Destroy(gameObject); 
        }
    }
}