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
        public List<GameObject> spreadFireTo;
        private bool onFire = false;
        private TileStateManager tsm;


        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            onFire = true;
            tsm = GetComponent<TileStateManager>();
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("executing");
            rend.material.SetColor("_Color", Color.red);

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
            foreach (var hitCollider in hitColliders)
            {
                Debug.Log(hitCollider);
                if (hitCollider.gameObject.GetComponent<TileStateManager>() != null && hitCollider.gameObject.GetComponent<TileStateManager>() != tsm)
                {
                    GameObject tiles = hitCollider.gameObject;
                    spreadFireTo.Add(tiles);
                }
                
                
            }

        }

        public override void Exit()
        {
            base.Exit();
            //tsm.ChangeState(smokeState);
            Debug.Log(tsm.currentState);
        }

        private void OnTriggerStay(Collider other)
        {
            other.GetComponent<EventManager>().CallTakeDamageEvent();
        }
    }
}