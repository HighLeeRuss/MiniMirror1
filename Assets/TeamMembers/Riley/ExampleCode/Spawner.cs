using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace RileyMcGowan
{
    public class Spawner : NetworkBehaviour
    {
        //Private Vars
        private List<GameObject> usedSpawnLocations;
        private List<GameObject> specialObjectsSpawned;
        private int tilesCounter;
        private NetworkManager networkManager;
        
        //Public Vars
        public List<GameObject> specialObjectsToSpawn;
        public GameObject playerPrefab;
        public List<GameObject> spawnedTiles;

        [Tooltip("Tiles to spawn")] 
        public GameObject[] spawnableTilesObjects;
        
        [Tooltip("How many tiles to spawn")]
        public Vector2 gridTileSpawn;
        
        
        public void SpawnScene()
        {
            if (isServer == false)
            {
                return;
            }
            networkManager = FindObjectOfType<NetworkManager>().GetComponent<NetworkManager>();
            spawnedTiles = new List<GameObject>();
            if (spawnableTilesObjects != null) ///TILE SPAWNER///
            {
                tilesCounter = 0;
                //Spawn the x grid
                for (int i = 0; i < gridTileSpawn.x; i++)
                {
                    int randomNumber = Random.Range(0, spawnableTilesObjects.Length);
                    GameObject tempSpawnObject = spawnableTilesObjects[randomNumber];
                    Vector3 spawnLocation = new Vector3(i, 0, 0);
                    Spawn(spawnLocation, tempSpawnObject, spawnedTiles);
                    
                    //Spawn the y grid
                    for (int j = 0; j < gridTileSpawn.y - 1; j++)
                    {
                        int randomNumberJ = Random.Range(0, spawnableTilesObjects.Length);
                        GameObject tempSpawnObjectJ = spawnableTilesObjects[randomNumberJ];
                        Vector3 spawnLocationJ = new Vector3(i, 0, j + 1);
                        Spawn(spawnLocationJ, tempSpawnObjectJ, spawnedTiles);
                    }
                }
            }
            else
            {
                Debug.LogWarning("The Spawner Has No Tiles");
            }

            for (int i = 0; i < specialObjectsToSpawn.Count; i++)
            {
                Spawn(networkManager.GetStartPosition().position,specialObjectsToSpawn[i], specialObjectsSpawned);
            }
            
            //Player Spawn Code
            /*
             * GameObject spawnLocation = locationsToSpawn[Random.Range(0, locationsToSpawn.Count)];
             * locationsToSpawn.Remove(spawnLocation);
             * Spawn(spawnLocation, playerGameobject, spawnLocations);
             */
        }

        public void Spawn(Vector3 locationToSpawn, GameObject objectToSpawn, List<GameObject> storeSpawnedObject)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, locationToSpawn, Quaternion.identity);
            NetworkServer.Spawn(spawnedObject);
            storeSpawnedObject.Add(spawnedObject);
        }
    }
}