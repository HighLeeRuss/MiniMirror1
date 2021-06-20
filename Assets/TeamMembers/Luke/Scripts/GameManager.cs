using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RileyMcGowan;

namespace Luke
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        /// maybe add a singleton here??
        /// </summary>

        //References

        //Events
        public event Action ResetLevelEvent;
        public event Action LoadLevelEvent;
        public event Action StartLevelEvent;
        public event Action GameLossEvent;
        public event Action GameWonEvent;

        //Variables
        
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        /// <summary>
        /// Send event to wipe a clean slate of tiles and bring back HP to players and protection points
        /// </summary>
        public void ResetLevel()
        {
            ResetLevelEvent?.Invoke();
        }

        /// <summary>
        /// Send event to setup of level before we start the game. Tell fire to do its thing + spawning positions and any PowerUps???
        /// </summary>
        public void LoadLevel()
        {
            LoadLevelEvent?.Invoke();
        }
        
        /// <summary>
        /// Send event to spawn Players and ProtectionPoints + start timer???
        /// </summary>
        public void StartLevel()
        {
            StartLevelEvent?.Invoke();
        }

        /// <summary>
        /// Send event to bring up end game screen and show finish time??? receive events from Protection Points and player HP
        /// </summary>
        public void GameLoss()
        {
            GameLossEvent?.Invoke();
        }

        /// <summary>
        /// Send event to bring up end game screen and show finish time??? check collective tiles in scene +  event from timer???
        /// </summary>
        public void GameWon()
        {
            GameWonEvent?.Invoke();
        }
    }
}

