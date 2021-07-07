using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    /*public override void OnStartServer()
    {
        base.OnStartServer();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
    }*/
    /*public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControlID)
    {
        base.OnServerAddPlayer(conn);
        var playerSpawned = (GameObject)GameObject.Instantiate(playerPrefab, GetStartPosition().position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, playerSpawned, playerControlID);
    }*/
}
