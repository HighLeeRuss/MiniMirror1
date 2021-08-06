using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerBase : NetworkBehaviour
{
    public NetworkConnection networkConnection;
    public string playerName;
    public GameObject gameO;
}
