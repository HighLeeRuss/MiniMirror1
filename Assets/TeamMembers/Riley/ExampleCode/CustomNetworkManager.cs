using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    
    private GameObject player = null;
    
    public List<Transform> spawnPoints;
    private int nextIndex = 0;

    [SerializeField] private GameObject playerSpawnSystem = null;

    //events
    public static event Action<NetworkConnection> OnServerReadied;


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
        gameManager.StartLevelEvent += SceneReadyForPlayer;
    }

    //TODO: probably belongs to spawner script  (player spawn function)
    public void SpawnPlayer(NetworkConnection conn)
    {
        Transform spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex);

        if (spawnPoint == null)
        {
            Debug.LogError($"Missing spawnPoint for player {nextIndex}");
            return;
        }

        GameObject playerInstance =
            Instantiate(playerPrefab, spawnPoints[nextIndex].position, spawnPoints[nextIndex].rotation);
        NetworkServer.Spawn(playerInstance, conn);

        nextIndex++;
    }

    public void SceneReadyForPlayer()
    {
        GameObject playerSpawnSystemInstance = Instantiate(playerSpawnSystem);
        NetworkServer.Spawn(playerSpawnSystemInstance);
    }
}
