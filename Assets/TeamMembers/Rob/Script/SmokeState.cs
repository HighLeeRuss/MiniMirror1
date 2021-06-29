using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rob;


namespace Rob
{
    public class SmokeState : StateBase
    
    
    {
        private Renderer rend;
        

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

        }

        public override void Execute()
        {
            base.Execute();

            rend.material.SetColor("Color", Color.gray);

            //if im smoking
            rend.material.SetColor("Color", Color.grey);

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