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

            rend.material.SetColor("Color", Color.gray);
            
            if (moistness == -1)
            {
                //GetComponent<TileStateManager>().ChangeState(waterState);
            }
           
            if (moistness == 0)
            {
               //GetComponent<TileStateManager>().ChangeState(fireState);
            }
            

        }

        public override void Exit()
        {
            base.Exit();
        }
        
    }
}