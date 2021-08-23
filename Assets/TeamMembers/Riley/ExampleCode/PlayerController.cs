using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RileyMcGowan
{
    public class PlayerController : PlayerBase
    {
        private PlayerInputBasic playerControlls; //Make a player controller for this player
        private Vector2 playerMoveVector;
        public float speed = 2;
        public GameObject waterGun;
        public GameObject pivotPoint;
        public GameObject waterSpawnable;
        private float horizontal;
        private float vertical;
        public CharacterController characterController;

        public override void OnStartServer()
        {
            base.OnStartServer();
            playerControlls = new PlayerInputBasic();
            playerControlls.Enable(); //Turn on action map
            playerControlls.InGame.Move.performed += MoveOnperformed;
            playerControlls.InGame.Move.canceled += MoveOnperformed;
            playerControlls.InGame.MouseClick.performed += ShootWater;
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
                SendVelocity();
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
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, transform.position.y, vertical);
            direction = Vector3.ClampMagnitude(direction, 1f);
            direction = transform.TransformDirection(direction);
            direction *= speed;
            characterController.SimpleMove(direction);
        }
    }
}