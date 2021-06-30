using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Rob
{

    [CustomEditor(typeof(EventManager), true)]
    public class EventManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Damage"))
            {
                ((EventManager) target).CallTakeDamageEvent();
            }

            if (GUILayout.Button("Death"))
            {
                
                ((EventManager) target).CallDeathEvent();
            }
            
            GUILayout.EndHorizontal();
        }
    }
}
