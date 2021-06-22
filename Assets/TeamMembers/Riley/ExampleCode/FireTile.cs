using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTile : MonoBehaviour
{
    //Private Vars
    private int fireCounter;
    private int fireMax = 10;
    private bool isTickActive;
    private bool currentlyOnFire;
    private bool currentlySmoking;
    private float fireDelay = 5;
    private Renderer currentRenderer;
    
    //Public Vars
    public bool toggleFire; //Is the tile currently burning
    
    void Start()
    {
        currentRenderer = GetComponent<Renderer>();
        currentRenderer.material.color = Color.gray; //Starting colour for the tile
        FireCounter = 0;
        if (toggleFire != false)
        {
            FireCounter = 10;
        }
    }

    void FixedUpdate()
    {
        //Is our tile on fire?
        if (toggleFire != true)
        {
            return;
        }
        
        if (isTickActive != true && FireCounter < fireMax)
        {
            StartCoroutine(FireTick(fireDelay));
        }
        
        if (FireCounter == fireMax)
        {
            DeActivateSmoke();
            ActivateFire();
        }
        else if (FireCounter > (fireMax/3)*2)
        {
            DeActivateFire();
            ActivateSmoke();
        }
        else if (FireCounter < (fireMax/3)*2)
        {
            DeActivateFire();
            DeActivateSmoke();
        }
    }

    //Our counter for fire with a delay
    IEnumerator FireTick(float delayFireTick)
    {
        isTickActive = true;
        if (FireCounter < fireMax)
        {
            FireCounter += 1;
        }
        yield return new WaitForSeconds(delayFireTick);
        isTickActive = false;
    }

    //Functions for networking "[ClientRPC]"
    private void ActivateFire()
    {
        currentlyOnFire = true;
        //Light Fire
        Debug.Log("Start " + gameObject + " Fire");
    }

    private void ActivateSmoke()
    {
        currentlySmoking = true;
        //Light Smoke
        Debug.Log("Start " + gameObject + " Smoke");
    }

    private void DeActivateFire()
    {
        currentlyOnFire = false;
        //Put Out Fire
        Debug.Log("End " + gameObject + " Fire");
    }

    private void DeActivateSmoke()
    {
        currentlySmoking = false;
        //Put Out Smoke
        Debug.Log("End " + gameObject + " Smoke");
    }

    /// <summary>
    /// Make var boundaries
    /// </summary>
    public int FireCounter
    {
        get
        {
            return fireCounter;
        }
        set
        {
            fireCounter = value;
            if (fireCounter > fireMax)
            {
                fireCounter = fireMax;
            }
        }
    }
}