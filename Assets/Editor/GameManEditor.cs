using System.Collections;
using System.Collections.Generic;
using LukeBaker;
using Mirror;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace LukeBaker
{
    [CustomEditor(typeof(GameManager))]
    public class GameManEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameManager gameManager = (GameManager) target;
            CustomNetworkManager customNetworkManager = gameManager.networkMan;
            
            if (GUILayout.Button("READY"))
            {
                customNetworkManager.OnServerReady(new NetworkConnectionToServer());
            }

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
