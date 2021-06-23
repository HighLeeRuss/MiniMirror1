using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rob
{ 
    public class StateManager : MonoBehaviour
    {
        public StateBase currentState;

        public void ChangeState(StateBase newState)
        {
            if (currentState != null)
            {
                currentState.active = false;
                currentState.Exit?.Invoke;
            }
		
            if (newState != null)
            {
                newState.active = true;
                newState.Enter?.Invoke;
                currentState = newState;
            }
        }
    }
}
