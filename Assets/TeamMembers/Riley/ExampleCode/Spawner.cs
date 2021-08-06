using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RileyMcGowan
{
    public class Spawner : NetworkBehaviour
    {
        //Private Vars
        private List<GameObject> usedSpawnLocations;
        private List<GameObject> specialObjectsSpawned;
        private int tilesCounter;
        private NetworkManager networkManager;
        private Vector2 compairSpecialSpawn;
        
        //Public Vars
        public List<GameObject> specialObjectsToSpawn;
        public GameObject playerPrefab;
        public List<GameObject> spawnedTiles;
        public GameObject fireTile;

        [Tooltip("Tiles to spawn")] 
        public GameObject[] spawnableTilesObjects;
        
        [Tooltip("How many tiles to spawn")]
        public Vector2 gridTileSpawn;

        private void Start()
        {
            SpawnScene();
        }

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
                        Vector2 roundInt = new Vector2(Mathf.Round(gridTileSpawn.x / 2), Mathf.Round(gridTileSpawn.y / 4));
                        compairSpecialSpawn = new Vector2(i, j);
                        if (compairSpecialSpawn == roundInt)
                        {
                            Vector3 spawnLocationJ = new Vector3(i, 0, j + 1);
                            Spawn(spawnLocationJ, fireTile, spawnedTiles);
                        }
                        else
                        {
                            int randomNumberJ = Random.Range(0, spawnableTilesObjects.Length);
                            GameObject tempSpawnObjectJ = spawnableTilesObjects[randomNumberJ];
                            Vector3 spawnLocationJ = new Vector3(i, 0, j + 1);
                            Spawn(spawnLocationJ, tempSpawnObjectJ, spawnedTiles);
                        }
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

        public void Spawn(Vector3 locationToSpawn, GameObject objectToSpawn, List<GameObject> storeSpawnedObject = default(List<GameObject>))
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, locationToSpawn, Quaternion.identity);
            NetworkServer.Spawn(spawnedObject);
            storeSpawnedObject.Add(spawnedObject);
        }

        public void RemoveScene()
        {
            for (int i = 0; i < spawnedTiles.Count; i++)
            {
                Destroy(spawnedTiles[i]);
            }
            for (int i = 0; i < specialObjectsSpawned.Count; i++)
            {
                Destroy(specialObjectsSpawned[i]);
            }
        }
    }
}