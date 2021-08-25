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
        private Vector3 resetVelocity = new Vector3(0, 0, 0);
        
        private void Awake()
        {
            thisRigidbody = GetComponent<Rigidbody>();
            thisRigidbody.AddRelativeForce(0,0,80);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<TileStateManager>() != null)
            {
                tileStateManager = other.gameObject.GetComponent<TileStateManager>();
                StartCoroutine(WetObject());
            }
        }
        
        IEnumerator WetObject()
        {
            thisRigidbody.velocity = resetVelocity;
            tileStateManager.beingWet = true;
            yield return new WaitForSeconds(3);
            tileStateManager.beingWet = false;
            Destroy(gameObject);
        }
    }
}