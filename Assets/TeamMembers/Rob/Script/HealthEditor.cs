using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rob
{
    
    [CustomEditor(typeof(Health), true)]
    public class HealthEditor : Editor
    {

       
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Damage"))
            {
                ((Health) target).DamageTaken(1f);
            }

            if (GUILayout.Button("Death"))
            {
                
                ((Health) target).CallDeathEvent();
            }
            
            GUILayout.EndHorizontal();
        }




    }
}