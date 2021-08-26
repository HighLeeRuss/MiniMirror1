using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Rob;
using UnityEngine.InputSystem;


namespace Rob
{
    public class SmokeState : StateBase
    {
        private Renderer rend;
        public StateBase fireState;
        public StateBase waterState;
        
        
        
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
        }

        [ClientRpc]
        public override void RpcChangeColour()
        {
            base.RpcChangeColour();
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            rend.material.SetColor("_Color", Color.gray);
        }
        
        public void ForcedChangeState()
        {
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            rend.material.SetColor("_Color", Color.gray);
        }
    }
}