using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rob;

namespace LukeBaker
{
    public class UIManager : MonoBehaviour
    {
        //References
        public Timer timer;
        public Canvas canvas;

        //variables
        public TextMeshProUGUI timerText;

        // Start is called before the first frame update
        void Start()
        {
            timerText = timer.GetComponentInChildren<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            PrintTimer();
        }

        /// Timer visuals only
        public void PrintTimer()
        {
            // on the left 0 for the minutes and right of the colon is 1 for seconds
            timerText.text = string.Format("{0:00}:{1:00}", timer.minutes, timer.seconds);
        }
    }
}