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
            
            if (GetComponent<StateCounter>().counter >= 0.7f)
            {
                GetComponent<TileStateManager>().ChangeState(fireState);
            }
           
            if ( GetComponent<StateCounter>().counter <= -0.7f)
            {
               GetComponent<TileStateManager>().ChangeState(waterState);
            }
            

        }

        public override void Exit()
        {
            base.Exit();
        }
        
    }
}