using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{
     
     public float zoomLevel;
     public float target;
     public float duration;
     private Vector3 ok;

     private void Start()
     {
          ok = new Vector3(2,2,2);
          //DOTween.To(Getter, Setter, target, duration).SetEase(Ease.OutBounce).onComplete(Finish);
          //duration += Time.deltaTime;
          DOTween.To(JustASetter, 0, 1, duration);
          transform.DOMove(ok, 1, true);
          transform.DOShakePosition(5, 1, 1000, 1000, true, true);
     }
     
     private void JustASetter(float newvalue)
     {
          transform.localScale = new Vector3(newvalue, newvalue, 1);
     }
     

     private float Getter()
     {
          return zoomLevel;
     }
     
     private void Setter(float pnewvalue)
     {
          zoomLevel = pnewvalue;
		
          transform.localScale = new Vector3(zoomLevel, zoomLevel, 1);
     }
     
     private void Finish()
     {
          // This only runs when the tween animated value is finished
          print("hi");
     }


}


