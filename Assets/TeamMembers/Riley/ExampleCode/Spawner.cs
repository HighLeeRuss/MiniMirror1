using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace RileyMcGowan
{
    public class Spawner : NetworkBehaviour
    {
        private List<GameObject> spawnedTiles;
        private int tilesCounter;

        [Tooltip("Tiles to spawn")] 
        public GameObject[] spawnableTilesObjects;
        public GameObject[] locationsToSpawn;
        
        [Tooltip("How many tiles to spawn")]
        public Vector2 gridTileSpawn;

        public override void OnStartServer()
        {
            base.OnStartServer();
            if (isServer == false)
            {
                return;
            }

            spawnedTiles = new List<GameObject>();
            if (spawnableTilesObjects != null) ///TILE SPAWNER///
            {
                tilesCounter = 0;
                //Spawn the x grid
                for (int i = 0; i < gridTileSpawn.x; i++)
                {
                    int randomNumber = Random.Range(0, spawnableTilesObjects.Length);
                    Vector3 spawnLocation = new Vector3(i, 0, 0);
                    SpawnTile(spawnLocation, randomNumber);
                    
                    //Spawn the y grid
                    for (int j = 0; j < gridTileSpawn.y - 1; j++)
                    {
                        int randomNumberJ = Random.Range(0, spawnableTilesObjects.Length);
                        Vector3 spawnLocationJ = new Vector3(i, 0, j + 1);
                        SpawnTile(spawnLocationJ, randomNumberJ);
                    }
                }
            }
            else
            {
                Debug.LogWarning("The Spawner Has No Tiles");
            }
        }

        private void SpawnTile(Vector3 spawnLocation, int toSpawn)
        {
            GameObject spawnedObject = Instantiate(spawnableTilesObjects[toSpawn], spawnLocation, Quaternion.identity);
            NetworkServer.Spawn(spawnedObject); //Spawn the object for the server
            spawnedTiles.Add(spawnedObject);
            tilesCounter += 1;
        }
    }
}