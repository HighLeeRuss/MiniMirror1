using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Reference
    public GameManager gameManager;
    
    //variables
    public float currentTime;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// called when resetting level
    /// </summary>
    public void ResetTime()
    {
        currentTime = 0;
    }

    /// <summary>
    /// On level start
    /// </summary>
    public void StartTime()
    {
        //currentTime = Time.time;

        if (currentTime > maxTime)
        {
            currentTime = maxTime;
        }
    }

    /// <summary>
    /// if we want to pause game
    /// </summary>
    public void PauseTime()
    {
        
    }

    private void OnEnable()
    {
        gameManager.StartLevelEvent += StartTime;
    }

    private void OnDisable()
    {
        gameManager.StartLevelEvent -= StartTime;
    }
}
