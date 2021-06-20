using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class GameStateManager : MonoBehaviour
    {
        //State Init
        public DelegateStateManager stateManager = new DelegateStateManager();
        public DelegateState startOfGame = new DelegateState();
        public DelegateState currentGame = new DelegateState();
        public DelegateState endOfGame = new DelegateState();

        private void Start()
        {
            //Tell the states what they have to run in the following order: (Enter, Update, Exit)
            startOfGame.Enter = EnterStartOfGame;
            startOfGame.Update = UpdateStartOfGame;
            startOfGame.Exit = ExitStartOfGame;
            currentGame.Enter = EnterCurrentGame;
            currentGame.Update = UpdateCurrentGame;
            currentGame.Exit = ExitCurrentGame;
            endOfGame.Enter = EnterEndOfGame;
            endOfGame.Update = UpdateEndOfGame;
            endOfGame.Exit = ExitEndOfGame;
            //Change the first state to startOfGame
            stateManager.ChangeState(startOfGame);
        }

        private void FixedUpdate()
        {
            //Remind the stateManager of what the current state is
            stateManager.UpdateCurrentState();
        }
        
        /// <summary>
        /// Start of game state
        /// </summary>
        private void EnterStartOfGame()
        {
            //This is where we : can start the UI ect.
        }
        private void UpdateStartOfGame()
        {
            //This is where we : tell the game to move to currentGame on play button press
        }
        private void ExitStartOfGame(){}

        /// <summary>
        /// Current game state
        /// </summary>
        private void EnterCurrentGame()
        {
            //This is where we : load the game itself, tiles ect or pass it off to a manager to load it.
        }

        private void UpdateCurrentGame()
        {
            //This is where we : tell the game to end once an objective has been passed
        }
        private void ExitCurrentGame(){}
        
        /// <summary>
        /// End of game state
        /// </summary>
        private void EnterEndOfGame()
        {
            //This is where we : start the end game UI or other elements to tell the player the game is over
        }
        private void UpdateEndOfGame(){}
        private void ExitEndOfGame(){}
        
    }
}