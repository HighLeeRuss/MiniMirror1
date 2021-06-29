using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;


namespace Rob
{
    public class SmokeState : StateBase
    
    
    {
        private Renderer rend;
<<<<<<< HEAD
        
        public override void Enter()
        {
            base.Enter();
            rend = GetComponent<Renderer>();
=======

        public void OnEnable()
        {
            FindObjectOfType<Health>().TakeDamage += Damage;
        }

        public void OnDisable()
        {
            FindObjectOfType<Health>().TakeDamage -= Damage;
        }
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
            rend = GetComponent<Renderer>(); //getting the renderer of the tile
>>>>>>> aed053d83527260cd9d31c3a3c57ac9abc3fd1d1
        }

        public override void Execute()
        {
            base.Execute();
<<<<<<< HEAD
            rend.material.SetColor("Color", Color.gray);
=======
            //if im smoking
            rend.material.SetColor("Color", Color.grey);
>>>>>>> aed053d83527260cd9d31c3a3c57ac9abc3fd1d1
        }

        public override void Exit()
        {
            base.Exit();
        }
        
        void Damage()
        {
            //do damage things
        }
    }
}