using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;

namespace Rob
{


    public class FireState : StateBase
    {
        private Renderer rend;

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

            //if you're on fire
            rend.material.SetColor("Color", Color.red);

        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}