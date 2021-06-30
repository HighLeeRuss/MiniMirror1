using System.Collections;
using System.Collections.Generic;
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
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
            
        }

        public override void Execute()
        {
            base.Execute();
            rend.material.SetColor("Color", Color.blue);
            
            if (moistness == 0)
            {
                //GetComponent<TileStateManager>().ChangeState(smokeState);
            }
            
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("we left");
        }
        
        
    }
}