using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class Editor : UnityEditor.Editor
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameManager gameManager = (GameManager) target;

        if (GUILayout.Button("Level Reset"))
        {
            gameManager.ResetLevel();
        }
        
        if (GUILayout.Button("Start Level"))
        {
            gameManager.CmdRequestStartLevel();
        }

        if (GUILayout.Button("Lose Level"))
        {
            gameManager.GameLoss();
        }

        if (GUILayout.Button("Win Level"))
        {
            gameManager.GameWon();
        }
    }
}
