using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class WallSpawnCode : MonoBehaviour
    {
        //Private Vars
        private Spawner mainSpawner;

        //Public Vars
        public List<Vector3> sideDirections;
        public LayerMask rayMask;

        void Start()
        {
            mainSpawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
            sideDirections.Add(Vector3.forward);
            sideDirections.Add(Vector3.back);
            sideDirections.Add(Vector3.left);
            sideDirections.Add(Vector3.right);
            CheckSides();
        }

        void CheckSides()
        {
            for (int i = 0; i < sideDirections.Count; i++)
            {
                RaycastHit raycastHitInfo;
                if (Physics.Raycast(transform.position, sideDirections[i], out raycastHitInfo, 1, rayMask))
                {
                    if (raycastHitInfo.distance < 1)
                    {
                        GameObject objectToReplace = raycastHitInfo.transform.gameObject;
                        Vector3 locationToSpawnTemp = new Vector3(objectToReplace.transform.position.x, 0,
                            objectToReplace.transform.position.z);
                        mainSpawner.Spawn(locationToSpawnTemp,
                            mainSpawner.spawnableTilesObjects
                                [Random.Range(0, mainSpawner.spawnableTilesObjects.Length)], mainSpawner.spawnedTiles);
                        mainSpawner.spawnedTiles.Remove(objectToReplace);
                        Destroy(objectToReplace);
                    }
                }
            }
        }
    }
}