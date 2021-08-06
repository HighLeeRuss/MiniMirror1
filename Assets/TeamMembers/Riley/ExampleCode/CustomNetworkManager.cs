using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    //references
    public GameManager gameManager;
    
    //variables
    private List<NetworkConnection> connections;
    private List<GameObject> playerGOs;

    private Transform startPos;
    private GameObject player;
    
    public List<Transform> startPositions;


    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    private void OnDisable()
    {
        gameManager.StartLevelEvent -= OnPlayerInstantiate;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        gameManager.StartLevelEvent += OnPlayerInstantiate;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //adding new players into a small lobby
        connections.Add(conn);
        playerGOs.Add(player);
    }
    public void OnPlayerInstantiate()
    {
        for (int i = 0; i < connections.Count; i++) 
        {
            startPos = GetStartPosition();
            
            playerGOs[i] = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerPrefab);
                
            // instantiating a "Player" prefab gives it the name "Player(clone)"
            // => appending the connectionId is WAY more useful for debugging!
            playerGOs[i].name = $"{playerPrefab.name} [connId={connections[i] .connectionId}]";
            NetworkServer.AddPlayerForConnection(connections[i], playerGOs[i]);
        }
    }
}
