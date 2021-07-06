using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rob
{

public class StateCounter : MonoBehaviour
{
    public bool onFire;
    public bool beingWet;
    public float counterTime;
    public float delay;
    public float counter;

    public StateBase fireState;
    public StateBase smokeState;
    public StateBase waterState;


    private void Update()
    {
        if (onFire)
        {
            FireCounter();
        }

        if (beingWet)
        {
            WaterCounter();
        }
    }

    void FireCounter()
    {
        counterTime += Time.deltaTime;

        if (counterTime >= delay)
        {
            counterTime = 0f;
            counter += 0.1f;
            if (counter >= 1)
            {
                counter = 1;
            }
        }
    }
    
    void WaterCounter()
    {
        counterTime += Time.deltaTime;

        if (counterTime >= delay)
        {
            counterTime = 0f;
            counter -= 0.1f;
            if (counter <= -1)
            {
                counter = -1;
            }
        }
    }
}
}
