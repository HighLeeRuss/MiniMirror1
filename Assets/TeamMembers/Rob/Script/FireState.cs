using System;
using System.Collections;
using System.Collections.Generic;
using Epic.OnlineServices.AntiCheatServer;
using Epic.OnlineServices.Lobby;
using Mirror;
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
        private bool onFire = false;
        private TileStateManager tsm;
        public Collider[] hitColliders;

        public override void Enter()
        {
            base.Enter();
            onFire = true;
            Debug.Log("Entered");
            tsm = GetComponent<TileStateManager>();
            hitColliders = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider hitCollider in hitColliders)
            {
                Debug.Log(hitCollider);
                TileStateManager tempTSM = hitCollider.gameObject.GetComponent<TileStateManager>();
                if (tempTSM != null && tempTSM != tsm)
                {
                    GameObject tiles = hitCollider.gameObject;
                    RpcChangeState(tempTSM);
                }
            }
            RpcChangeColour();
        }

        public override void Execute()
        {
            base.Execute();
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
        
        [ClientRpc]
        public override void RpcChangeColour()
        {
            base.RpcChangeColour();
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            rend.material.SetColor("_Color", Color.red);
        }
        
        [ClientRpc]
        public void RpcChangeState(TileStateManager tileSM)
        {
            tileSM.onFire = true;
        }
    }
}