using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RileyMcGowan
{
    public class PlayerController : PlayerBase
    {
        private PlayerInputBasic playerControls; //Make a player controller for this player
        private Vector2 playerMoveVector;
        public float speed = 2;
        public GameObject waterGun;
        public GameObject pivotPoint;
        public GameObject waterSpawnable;
        private float horizontal;
        private float vertical;
        public CharacterController characterController;

        public override void OnStartClient()
        {
            base.OnStartClient();
            playerControls = new PlayerInputBasic();
            playerControls.Enable(); //Turn on action map
            if (isLocalPlayer)
            {
                //Grab a control performed > Ignore the provided context > Input the client position and rotation
                playerControls.InGame.MouseClick.performed += context => CmdShootWater(waterGun.transform.position, waterGun.transform.rotation);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                MovePlayer();
                //Detect Player Mouse Pos
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

        void MovePlayer()
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

        [Command()] //Register Command
        private void CmdShootWater(Vector3 waterGun, Quaternion gunRotation)
        {
            //Pass the client info through as a command
            ShootWater(waterGun, gunRotation);
        }

        private void ShootWater(Vector3 waterGun, Quaternion gunRotation)
        {
            GameObject spawnedWater = Instantiate(waterSpawnable, waterGun, gunRotation);
            NetworkServer.Spawn(spawnedWater);
        }
    }
}