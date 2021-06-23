using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;


namespace Rob
{
    public class SmokeState : StateBase
    {
        private Renderer rend;
        
        public override void Enter()
        {
            base.Enter();
            rend = GetComponent<Renderer>();
        }

        public override void Execute()
        {
            base.Execute();
            rend.material.SetColor("Color", Color.gray);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}