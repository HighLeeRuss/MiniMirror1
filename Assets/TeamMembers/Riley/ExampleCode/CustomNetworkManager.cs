using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LukeBaker;
using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    //references
    public GameManager gameManager;
    
    //variables
    private List<NetworkConnection> connections;
    private List<GameObject> playerGOs;
    
    [SerializeField] private GameObject playerSpawnSystem = null;

    //events
    public static event Action<NetworkConnection> OnServerReadiedEvent;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnDisable()
    {
        gameManager.StartLevelEvent -= SceneReadyForPlayer;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        
        gameManager.StartLevelEvent += SceneReadyForPlayer;
    }

    public void SceneReadyForPlayer()
    {
        GameObject playerSpawnSystemInstance = Instantiate(playerSpawnSystem);
        NetworkServer.Spawn(playerSpawnSystemInstance);
    }

    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);
        
        OnServerReadiedEvent?.Invoke(conn);
    }
}
