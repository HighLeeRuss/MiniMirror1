using System;
using System.Collections;
using System.Collections.Generic;
using Rob;
using UnityEngine;

namespace RileyMcGowan
{
    public class WaterCollision : MonoBehaviour
    {
        private TileStateManager tileStateManager;
        private Rigidbody thisRigidbody;
        
        private void Awake()
        {
            thisRigidbody = GetComponent<Rigidbody>();
            thisRigidbody.AddRelativeForce(100,0,0);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<TileStateManager>() != null)
            {
                tileStateManager = other.gameObject.GetComponent<TileStateManager>();
                StartCoroutine(WetObject());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        IEnumerator WetObject()
        {
            thisRigidbody.isKinematic = true;
            tileStateManager.beingWet = true;
            yield return new WaitForSeconds(3);
            tileStateManager.beingWet = false;
            Destroy(gameObject);
        }
    }
}