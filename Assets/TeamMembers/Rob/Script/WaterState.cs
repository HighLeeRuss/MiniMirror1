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
        //private TileStateManager tileStateManagerRef;
        
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
            rend.material.SetColor("Color", Color.blue);
            /*if (GetComponent<TileStateManager>().counter >= -0.5f)
            {
                GetComponent<TileStateManager>().ChangeState(smokeState);
            }*/
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("we left");
        }
        
        
    }
}