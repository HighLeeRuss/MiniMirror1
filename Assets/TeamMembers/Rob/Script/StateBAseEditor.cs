using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Rob;

[CustomEditor(typeof(StateBase), true)]

public class StateBAseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Force Enter"))
        {
            Debug.Log("PRESSED!");
        }
        
        base.OnInspectorGUI();
        if (GUILayout.Button("Force Execute"))
        {
            Debug.Log("Executing!!!");
        }
        
        base.OnInspectorGUI();
        if (GUILayout.Button("Force Exit"))
        {
            Debug.Log("EXIT!");
        }
    }
}
