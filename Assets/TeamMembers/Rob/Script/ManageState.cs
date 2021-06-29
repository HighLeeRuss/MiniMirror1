using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;


namespace Rob
{

    public class ManageState : MonoBehaviour
    {
        public int moist;
        public TileStateManager stateManager = new TileStateManager();
        public StateBase fireState = new FireState();
        public StateBase smokeState = new SmokeState();
        public StateBase waterState = new WaterState();



        private void Start()
        {
            moist = 10;
        }
        private void FixedUpdate()
        {
            //Remind the stateManager of what the current state is
            stateManager.UpdateCurrentState();
        }

        
    }



}





    
