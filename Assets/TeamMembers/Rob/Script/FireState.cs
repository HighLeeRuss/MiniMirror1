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
        private int moistness;
        //private TileStateManager tileStateManagerRef;

        /*public void OnEnable()
        {
            FindObjectOfType<EventManager>().OnDamageEvent += DealDamage;
        }

        public void OnDisable()
        {
            FindObjectOfType<EventManager>().OnDamageEvent -= DealDamage;
        }*/

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            //tileStateManagerRef = GetComponent<TileStateManager>();
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("executing");
            rend.material.SetColor("Color", Color.red);
            /*if (tileStateManagerRef.counter <= 0.5f)
            {
                tileStateManagerRef.ChangeState(smokeState);
            }*/
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void OnTriggerStay(Collider other)
        {
            other.GetComponent<EventManager>().CallTakeDamageEvent();
        }
    }
}