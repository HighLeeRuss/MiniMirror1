using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RileyMcGowan
{

    public class PlayerMovement : NetworkBehaviour
    {
        private PlayerInputBasic playerControlls; //Make a player controller for this player
        private Rigidbody rb;
        private Vector2 playerMoveVector;
        private float speed = 10;
        private float maxSpeed = 15;

        public override void OnStartServer()
        {
            base.OnStartServer();
            playerControlls = new PlayerInputBasic();
            playerControlls.Enable(); //Turn on action map
            playerControlls.InGame.Move.performed += MoveOnperformed;
            playerControlls.InGame.Move.canceled += MoveOnperformed;
            rb = GetComponent<Rigidbody>();
        }

        private void MoveOnperformed(InputAction.CallbackContext obj)
        {
            playerMoveVector = obj.ReadValue<Vector2>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rb.velocity.x < maxSpeed)
            {
                rb.AddRelativeForce(playerMoveVector.x * speed, 0, 0);
            }
            if (rb.velocity.z < maxSpeed)
            {
                rb.AddRelativeForce(0, 0, playerMoveVector.y * speed);
            }
        }


    }
}