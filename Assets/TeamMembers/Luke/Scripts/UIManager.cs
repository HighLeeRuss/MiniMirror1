using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Luke
{
    public class UIManager : NetworkBehaviour
    {
        //References
        public Timer timer;

        //variables
        public TextMeshProUGUI TimerText;
        
        // Start is called before the first frame update
        void Start()
        {
            TimerText = timer.GetComponentInChildren<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            CmdRequestPrintTimer();
        }

        public void ShowHealthBar()
        {
            
        }

        /// <summary>
        /// server
        /// </summary>
        [Command(requiresAuthority = false)]
        public void CmdRequestPrintTimer()
        {
            RpcPrintTimer();
        }

        /// <summary>
        /// client
        /// </summary>
        [ClientRpc]
        public void RpcPrintTimer()
        {
            TimerText.text = timer.currentTime.ToString();
        }
    }
}
