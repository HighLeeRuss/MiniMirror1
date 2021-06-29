using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rob
{
    
    

        //[Serializable]
    public class StateBase : MonoBehaviour
    { 
            
        //public Action Enter;
        //public Action Execute;
        //public Action Exit;
        public bool active;

        public virtual void Enter()
        {
            
        }

        public virtual void Execute()
        {
            
        }    

        public virtual void Exit()
        {
            
        }
    }
}
