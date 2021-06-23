using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using Mirror;
using UnityEngine;

namespace Luke
{
    public class Timer : NetworkBehaviour
    {
        //Reference
        public GameManager gameManager;

        //variables
        public float currentTime;
        public float maxTime;
        public bool timeStarted;

        //events
        public event Action TimerEndEvent;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (timeStarted)
            {
                UpdateTime();
            }
        }

        /// <summary>
        /// called when resetting level
        /// </summary>
        public void ResetTime()
        {
            currentTime = 0;
        }

        /// <summary>
        /// On level start
        /// </summary>
        public void StartTime()
        {
            if (isServer)
            {
                timeStarted = true;
                currentTime = maxTime;
            }
        }

        public void UpdateTime()
        {
            if (isServer)
            {
                currentTime -= Time.deltaTime;

                if (currentTime <= 0)
                {
                    PauseTime();
                    //Game over stuff wants to know this
                    TimerEndEvent?.Invoke();
                }
            }
        }

        /// <summary>
        /// if we want to pause game
        /// </summary>
        public void PauseTime()
        {
            
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            if (isServer)
            {
                gameManager.StartLevelEvent += StartTime;
            }
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            
            if (isServer)
            {
                gameManager.StartLevelEvent -= StartTime;
            }
            
        }
    }
}