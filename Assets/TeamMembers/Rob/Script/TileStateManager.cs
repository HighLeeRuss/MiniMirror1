using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LukeBaker;
using Mirror;

namespace Rob
{ 
    public class TileStateManager : NetworkBehaviour
    {
        public StateBase currentState;
        public bool onFire;
        public bool beingWet;
        public float counterTime;
        public float delay;
        [SyncVar]
        public float counter;
        
        private FireState fireState;
        private WaterState waterState;
        private SmokeState smokeState;

        public override void OnStartServer()
        {
            base.OnStartServer();
            fireState = GetComponent<FireState>();
            waterState = GetComponent<WaterState>();
            smokeState = GetComponent<SmokeState>();
        }

        public override void OnStartClient()
        {
            base.OnStartLocalPlayer();
            GetComponent<SmokeState>().ForcedChangeState();
        }

        /// <summary>
        /// Core
        /// </summary>
        private void FixedUpdate()
        {
            if (fireState == null || waterState == null || smokeState == null)
            {
                fireState = GetComponent<FireState>();
                waterState = GetComponent<WaterState>();
                smokeState = GetComponent<SmokeState>();
            }
            if (isServer)
            {
                if (onFire)
                {
                    FireCounter();
                }
            
                if (beingWet)
                {
                    WaterCounter();
                }

                if (Counter > 0.7f && currentState != fireState)
                {
                    ChangeState(fireState);
                }
                else if (Counter < -0.7f && currentState != waterState)
                {
                    ChangeState(waterState);
                }
                else if (Counter < 0.7f && Counter > -0.7f && currentState != smokeState)
                {
                    ChangeState(smokeState);
                }
                
                //Remind what the current state is
                currentState?.Execute();
            }
        }
        
        /// <summary>
        /// Functions
        /// </summary>
        /// <param name="newState"></param>
        
        
        void FireCounter()
        {
            counterTime += Time.deltaTime;
            if (counterTime >= delay * 2)
            {
                counterTime = 0f;
                Counter += 0.1f;
            }
        }
        
        void WaterCounter()
        {
            counterTime += Time.deltaTime;
            if (counterTime >= delay)
            {
                counterTime = 0f;
                Counter -= 0.15f;
            }
        }
        
        /// <summary>
        /// CounterLimits
        /// </summary>
        public float Counter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
                if (counter > 1f)
                {
                    counter = 1f;
                }

                if (counter < -1f)
                {
                    counter = -1f;
                }
            }
        }
        
        private void ChangeState(StateBase newState)
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
    }
}
