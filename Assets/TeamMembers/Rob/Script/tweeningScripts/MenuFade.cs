using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Rob;
using UnityEditor;

namespace Rob
{



   public class MenuFade : MonoBehaviour
   {
      public CanvasGroup cg;
      public float textAlpha;


      private void Start()
      {
         cg.alpha = 0;
         
      }

      public void MenuAppear()
      {
         DOTween.To(Getter, Setter, 1, 5f);//.SetEase(Ease.OutBounce);
      }
      
      private float Getter()
      {
         return textAlpha;
      }

      private void Setter(float newValue)
      {
         textAlpha = newValue;

         GetComponent<CanvasGroup>().alpha = textAlpha;
      }
   }
}