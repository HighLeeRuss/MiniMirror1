using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;


namespace Rob
{
    public class SmokeState : StateBase
    {
        private Renderer rend;
        public StateBase fireState;
        public StateBase waterState;
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
            rend.material.SetColor("Color", Color.gray);
            /*if (tileStateManagerRef.counter >= 0.7f)
            {
                tileStateManagerRef.ChangeState(fireState);
            }
            if (tileStateManagerRef.counter <= -0.7f)
            {
                tileStateManagerRef.ChangeState(waterState);
            }*/
        }

        public override void Exit()
        {
            base.Exit();
        }
        
    }
}