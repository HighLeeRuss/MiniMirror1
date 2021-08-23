using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rob
{ 
    public class TileStateManager : MonoBehaviour
    {
        public StateBase currentState;
        public bool onFire;
        public bool beingWet;
        public float counterTime;
        public float delay;
        public float counter;
        

        private FireState fireState;
        private WaterState waterState;
        private SmokeState smokeState;


        private void Start()
        {
            fireState = FindObjectOfType<FireState>();
            waterState = FindObjectOfType<WaterState>();
            smokeState = FindObjectOfType<SmokeState>();

            currentState = smokeState;
        }

        /// <summary>
        /// Core
        /// </summary>
        private void FixedUpdate()
        {
            if (onFire)
            {
                FireCounter();
            }

            if (beingWet)
            {
                WaterCounter();
            }

            if (fireState.spreadFireTo.Count > 0)
            {
                foreach (GameObject tile in fireState.spreadFireTo)
                {
                    Debug.Log(tile);
                    tile.GetComponent<TileStateManager>().onFire = true;
                }
            }



            if (Counter > 0.75f && currentState != fireState)
            {
                ChangeState(fireState);
            }
            
            else if (Counter < -0.75f && currentState != waterState)
            {
                ChangeState(waterState);
            }

            if (Counter < 0.7f && Counter > -0.7f)
            {
                ChangeState(smokeState);
            }
            
            






            //Remind what the current state is
            currentState?.Execute();
        }
        
        /// <summary>
        /// Functions
        /// </summary>
        /// <param name="newState"></param>
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
        
        void FireCounter()
        {
            counterTime += Time.deltaTime;
            if (counterTime >= delay)
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
                Counter -= 0.1f;
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
    }
}
