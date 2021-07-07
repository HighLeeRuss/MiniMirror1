using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class ThreadTest : MonoBehaviour
{
    // Start is called before the first frame update

    public int threadCount; 
    public int millisecThreadSleepCounter;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < threadCount; i++)
        {
            Thread thread = new Thread(DoStuff);
            thread.Start();
        }
    }

    public void DoStuff()
    {
        Debug.Log("Start thread");
        Thread.Sleep(millisecThreadSleepCounter);
        Debug.Log("End thread");
    }
}
