using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using Rob;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private TileStateManager tSM;
    private bool isFireDamaging;
    
    // Start is called before the first frame update
    void Start()
    {
        tSM = GetComponentInParent<TileStateManager>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.GetComponent<PlayerController>() != null && isFireDamaging == false)
        {
            if (tSM.Counter > 0.75f)
            {
                StartCoroutine(FireDamage(col.gameObject));
            }
        }
    }

    IEnumerator FireDamage(GameObject gO)
    {
        isFireDamaging = true;
        gO.GetComponent<Health>().DamageEventTaken(1);
        yield return new WaitForSeconds(2);
        isFireDamaging = false;
    }
    
}
