using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using Mirror;
using UnityEngine;

public class SoundManager : NetworkBehaviour
{
    //Reference
    public GameManager gameManager;
    
    //Variables
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        
        if (isServer)
        {
            gameManager.StartLevelEvent += RpcStartMusic;
        }
    }

    [ClientRpc]
    public void RpcStartMusic()
    {
        Debug.Log("playing music now");
    }
}
