using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DummyThreadingCode : MonoBehaviour
{
    private bool isActiveCo;
    void Start()
    {
        isActiveCo = false;
        StartCoroutine(TimerForDoStuff());
    }
    
    void Update()
    {
        if (isActiveCo != true)
        {
            StartCoroutine(TimerForDoStuff());
        }
    }

    private IEnumerator TimerForDoStuff()
    {
        isActiveCo = true;
        yield return new WaitForSeconds(5);
        Thread threadToUse = new Thread(DoStuff);
        threadToUse.Start();
    }
    
    void DoStuff()
    {
        Debug.Log("StartThread");
        Thread.Sleep(3000);
        Debug.Log("End thread");
        lock (this)
        {
            isActiveCo = false;
        }
    }
}
