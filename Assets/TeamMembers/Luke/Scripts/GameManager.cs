using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using RileyMcGowan;

namespace LukeBaker
{
    public class GameManager : NetworkBehaviour
    {
        //References
        private GameStateManager gameStateManager;
        public CustomNetworkManager networkMan;
        public Timer timer;
        public Camera camera;
        public Spawner spawner;

        //Events
        public event Action ResetLevelEvent;
        public event Action LoadLevelEvent;
        public event Action StartLevelEvent;
        public event Action GameLossEvent;
        public event Action GameWonEvent;

        //Variables


        private void OnEnable()
        {
            timer.TimerEndEvent += RequestGameLoss;
            gameStateManager = GetComponent<GameStateManager>();
            networkMan = GetComponent<CustomNetworkManager>();
        }

        private void OnDisable()
        {
            timer.TimerEndEvent -= RequestGameLoss;
        }

        /// <summary>
        /// Send event to wipe a clean slate of tiles and bring back HP to players and protection points
        /// </summary>
        [Command(requiresAuthority = false)]
        public void CmdRequestResetLevel()
        {
            RpcResetLevel();
        }
        
        [ClientRpc]
        public void RpcResetLevel()
        {
            ResetLevelEvent?.Invoke();
            spawner.RemoveScene();
        }

        /// <summary>
        /// Send event to setup of level before we start the game. Set up tiles, spawning positions and any PowerUps???
        /// </summary>
        public void LoadLevel()
        {
            LoadLevelEvent?.Invoke();
            spawner.SpawnScene();
        }

        /// <summary>
        /// Send event to spawn Players and ProtectionPoints + start timer???
        /// </summary>
        public void StartLevel()
        {
            StartLevelEvent?.Invoke();
            gameStateManager.stateManager.ChangeState(gameStateManager.startOfGame);
        }

        /// <summary>
        /// Send event to bring up end game screen and show finish time??? receive events from Protection Points and player HP
        /// </summary>
        [Command(requiresAuthority = false)]
        public void RequestGameLoss()
        {
            RpcGameLoss();
        }
        
        [ClientRpc]
        public void RpcGameLoss()
        {
            GameLossEvent?.Invoke();
            gameStateManager.stateManager.ChangeState(gameStateManager.endOfGame);
        }

        /// <summary>
        /// Send event to bring up end game screen and show finish time??? check collective tiles in scene + event from timer???
        /// </summary>
        [Command(requiresAuthority = false)]
        public void CmdRequestGameWon()
        {
            RpcGameWon();
        }
        
        [ClientRpc]
        public void RpcGameWon()
        {
            GameWonEvent?.Invoke();
            gameStateManager.stateManager.ChangeState(gameStateManager.endOfGame);
        }
    }
}

