using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using Mirror;
using UnityEngine;

namespace Luke
{
    public class SoundManager : NetworkBehaviour
    {
        //Reference
        public GameManager gameManager;

        //Variables

        public override void OnStartServer()
        {
            base.OnStartServer();

            if (isServer)
            {
                gameManager.StartLevelEvent += RpcStartMusic;
            }
        }

        public override void OnStopServer()
        {
            base.OnStopServer();

            if (isServer)
            {
                gameManager.StartLevelEvent -= RpcStartMusic;
            }
        }

        //TODO find some actual music
        [ClientRpc]
        public void RpcStartMusic()
        {
            Debug.Log("playing music now");
        }
    }
}
