using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

namespace Rob
{
    
    

        //[Serializable]
    public class StateBase : NetworkBehaviour
    {
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

        [ClientRpc]
        public virtual void RpcChangeColour()
        {
            
        }
    }
}
