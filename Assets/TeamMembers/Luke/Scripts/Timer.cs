using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using Mirror;
using UnityEngine;

public class Timer : NetworkBehaviour
{
    //Reference
    public GameManager gameManager;
    
    //variables
    public float currentTime;
    public float maxTime;
    private float tick;
    
    //events
    public event Action TimerEndEvent;

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
        if (isServer)
        {
            currentTime = maxTime;
            tick = 1f;
            currentTime -= tick;
          
            if (currentTime <= 0)
            {
                //Game over stuff wants to know this
                TimerEndEvent?.Invoke();
            }  
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
        if (isServer)
        {
            gameManager.StartLevelEvent += StartTime;
        }
    }

    private void OnDisable()
    {
        if (isServer)
        {
            gameManager.StartLevelEvent -= StartTime;
        }
    }
}
