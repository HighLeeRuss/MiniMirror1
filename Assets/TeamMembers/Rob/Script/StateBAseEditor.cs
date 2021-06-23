using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Rob;



namespace Rob
{
    [CustomEditor(typeof(StateBase), true)]

    public class StateBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();

            //base.OnInspectorGUI();
            if (GUILayout.Button("Force Enter"))
            {
                ((StateBase) target).Enter();
            }

            //base.OnInspectorGUI();
            if (GUILayout.Button("Force Execute"))
            {
                ((StateBase) target).Execute();
            }

            //base.OnInspectorGUI();
            if (GUILayout.Button("Force Exit"))
            {
                ((StateBase) target).Exit();
            }

            GUILayout.EndHorizontal();
        }
    }
}