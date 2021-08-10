using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

namespace LukeBaker
{
    public class PlayerSpawnSystem : NetworkBehaviour
    {
        //variables
        [SerializeField]private GameObject player = null;
        private int nextIndex = 0;
        private static List<Transform> spawnPoints = new List<Transform>();

        public static void AddSpawnPoint(Transform transform)
        {
            spawnPoints.Add(transform);

            spawnPoints = spawnPoints.OrderBy(x => x.GetSiblingIndex()).ToList();
        }

        public static void RemoveSpawnPoint(Transform transform)
        {
            spawnPoints.Remove(transform);
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            CustomNetworkManager.OnServerReadiedEvent += SpawnPlayer;
        }

        [ServerCallback]
        private void OnDestroy()
        {
            CustomNetworkManager.OnServerReadiedEvent -= SpawnPlayer;
        }

        //TODO: probably belongs to spawner script  (player spawn function)
        [Server]
        public void SpawnPlayer(NetworkConnection conn)
        {
            Transform spawnPoint = spawnPoints.ElementAtOrDefault(nextIndex);

            if (spawnPoint == null)
            {
                Debug.LogError($"Missing spawnPoint for player {nextIndex}");
                return;
            }

            GameObject playerInstance =
                Instantiate(player, spawnPoints[nextIndex].position, spawnPoints[nextIndex].rotation);
            NetworkServer.Spawn(playerInstance, conn);

            nextIndex++;
        }
    }
}
