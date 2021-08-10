using System;
using System.Collections;
using System.Collections.Generic;
using LukeBaker;
using Mirror;
using UnityEngine;

namespace LukeBaker
{
    public class Timer : NetworkBehaviour
    {
        //Reference
        public GameManager gameManager;

        //variables
        public float currentTime;
        public float maxTime;
        public bool timeStarted;
        [SyncVar]
        public float minutes;
        [SyncVar]
        public float seconds;

        //events
        public event Action TimerEndEvent;

        // Update is called once per frame
        void Update()
        {
            if (timeStarted)
            {
                CmdRequestUpdateTime();
            }
        }

        /// <summary>
        /// called when resetting level
        /// </summary>
        public void ResetTime()
        {
            currentTime = maxTime;
        }

        /// <summary>
        /// On level start
        /// </summary>

        [Command(requiresAuthority = false)]
        public void CmdRequestStartTime()
        {
            RpcStartTime();
        }
        
        [ClientRpc]
        public void RpcStartTime()
        {
            if (isServer)
            {
                timeStarted = true;
                currentTime = maxTime;
            }
        }

        [Command(requiresAuthority = false)]
        public void CmdRequestUpdateTime()
        {
            RpcUpdateTime(currentTime);
        }

        [ClientRpc]
        public void RpcUpdateTime(float displayTime)
        {
            if (isServer)
            {
                currentTime -= Time.deltaTime;

                if (currentTime <= 0)
                {
                    currentTime = 0;
                    PauseTime();
                    //Game over stuff wants to know this
                    TimerEndEvent?.Invoke();
                }

                //making the timer have minutes and seconds limits
                minutes = Mathf.FloorToInt(displayTime / 60);
                seconds = Mathf.FloorToInt(displayTime % 60);
                
                //TODO: the zero second isn't actually zero when it ticks (still some milliseconds to consider)
            }
        }
        

        /// <summary>
        /// if we want to pause game would be useful to have this
        /// </summary>
        public void PauseTime()
        {
            
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            if (isServer)
            {
                gameManager.StartLevelEvent += CmdRequestStartTime;
            }
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            
            if (isServer)
            {
                gameManager.StartLevelEvent -= CmdRequestStartTime;
            }
        }
    }
}