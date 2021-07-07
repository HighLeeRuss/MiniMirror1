using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Rob;

namespace Rob
{



  public class MenuMove : MonoBehaviour
  {
    public float uiStart;



    private void Start()
    {
      DOTween.To(Getter, Setter, 315f, 4f).SetEase(Ease.InOutElastic).OnComplete(Finish);
    }

    private float Getter()
    {
      return uiStart;
    }

    private void Setter(float newValue)
    {
      uiStart = newValue;

      transform.localPosition = new Vector3(0, uiStart, 0);
    }

    void Finish()
    {
      //do this
      Debug.Log("finished");
      FindObjectOfType<MenuFade>().MenuAppear();
    }
  }
}
