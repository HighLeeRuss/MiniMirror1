using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RileyMcGowan
{
    public class PlayerController : NetworkBehaviour
    {
        private PlayerInputBasic playerControlls; //Make a player controller for this player
        private Rigidbody rb;
        private Vector2 playerMoveVector;
        private float speed = 10;
        private float maxSpeed = 15;
        public GameObject waterGun;
        public GameObject pivotPoint;
        public GameObject waterSpawnable;

        public override void OnStartServer()
        {
            base.OnStartServer();
            playerControlls = new PlayerInputBasic();
            playerControlls.Enable(); //Turn on action map
            playerControlls.InGame.Move.performed += MoveOnperformed;
            playerControlls.InGame.Move.canceled += MoveOnperformed;
            playerControlls.InGame.MouseClick.performed += ShootWater;
            rb = GetComponent<Rigidbody>();
        }

        private void MoveOnperformed(InputAction.CallbackContext obj)
        {
            playerMoveVector = obj.ReadValue<Vector2>();
        }
        
        private void ShootWater(InputAction.CallbackContext obj)
        {
            Instantiate(waterSpawnable, waterGun.transform.position, waterGun.transform.rotation);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                if (rb == null && GetComponent<Rigidbody>() != null)
                {
                    rb = GetComponent<Rigidbody>();
                }
                if (rb.velocity.x < maxSpeed)
                {
                    rb.AddRelativeForce(playerMoveVector.x * speed, 0, 0);
                    //SendVelocity();
                }
                if (rb.velocity.z < maxSpeed)
                {
                    rb.AddRelativeForce(0, 0, playerMoveVector.y * speed);
                }
                Plane plane = new Plane(Vector3.up, 0);

                float distance;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out distance))
                {
                    Vector3 worldPosition = ray.GetPoint(distance);
                    pivotPoint.transform.LookAt(new Vector3(worldPosition.x, waterGun.transform.position.y, worldPosition.z));
                }
            }
        }

        void SendVelocity()
        {
            //cmdSendVelocity;
        }
    }
}