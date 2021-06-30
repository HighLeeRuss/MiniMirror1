using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rob
{ 
    public class TileStateManager : MonoBehaviour
    {
        public StateBase currentState;

        public void ChangeState(StateBase newState)
        {
            if (currentState != null)
            {
                currentState.active = false;
                currentState.Exit();
            }
		
            if (newState != null)
            {
                newState.active = true;
                newState.Enter(); 
                currentState = newState;
            }
        }
        
        public void UpdateCurrentState()
        {
            currentState?.Execute();
        }
        
        private void FixedUpdate()
        {
            //Remind what the current state is
            UpdateCurrentState();
        }
    }
}
