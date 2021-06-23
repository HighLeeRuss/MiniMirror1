using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Luke
{
    public class UIManager : MonoBehaviour
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
            PrintTimer();
        }

        public void ShowHealthBar()
        {
            
        }

        public void PrintTimer()
        {
            TimerText.text = timer.currentTime.ToString();
        }


    }
}
