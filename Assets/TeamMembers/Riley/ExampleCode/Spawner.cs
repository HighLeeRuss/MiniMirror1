using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class Spawner : MonoBehaviour
    {
        private GameObject[] spawnedTiles;

        [Tooltip("Tiles to spawn")] 
        public GameObject[] spawnableTilesObjects;
        public GameObject[] locationsToSpawn;
        
        [Tooltip("How many tiles to spawn")]
        public Vector2 gridTileSpawn;

        void Start()
        {
            if (spawnableTilesObjects != null) ///TILE SPAWNER///
            {
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

        //[ClientRpc]
        private void SpawnTile(Vector3 spawnLocation, int toSpawn)
        {
            Instantiate(spawnableTilesObjects[toSpawn], spawnLocation, Quaternion.identity);
        }
    }
}