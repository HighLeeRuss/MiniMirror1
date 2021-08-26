using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

using Rob;

namespace Rob
{
    public class WaterState : StateBase
    {
        private Renderer rend;
        public StateBase smokeState;
        private int moistness;

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
            if (isServer)
            {
                RpcChangeColour();
            }
        }

        public override void Execute()
        {
            base.Execute();
           
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("we left");
        }

        [ClientRpc]
        public override void RpcChangeColour()
        {
            base.RpcChangeColour();
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            rend.material.SetColor("_Color", Color.blue);
        }
        
        public void ForcedChangeState()
        {
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            rend.material.SetColor("_Color", Color.blue);
        }
    }
}