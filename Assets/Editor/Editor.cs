using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace Luke
{
    [CustomEditor(typeof(GameManager))]
    public class Editor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameManager gameManager = (GameManager) target;

            if (GUILayout.Button("Level Reset"))
            {
                gameManager.CmdRequestResetLevel();
            }

            if (GUILayout.Button("Load Level"))
            {
                gameManager.LoadLevel();
            }

            if (GUILayout.Button("Start Level"))
            {
                gameManager.StartLevel();
            }

            if (GUILayout.Button("Lose Level"))
            {
                gameManager.RequestGameLoss();
            }

            if (GUILayout.Button("Win Level"))
            {
                gameManager.CmdRequestGameWon();
            }
        }
    }
}
