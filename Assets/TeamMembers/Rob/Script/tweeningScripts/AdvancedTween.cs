using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;

public class AdvancedTween : MonoBehaviour
{

    public float target;
    public float duration;
    public float zoomLevel;

    public Transform MyTransform;

    void Start()
    {
        DOTween.To(Getter, Setter, target, duration).SetEase(Ease.OutBounce).OnComplete(Finish);
    }

    private float Getter()
    {
        return zoomLevel;
    }

    private void Setter(float pnewvalue)
    {
        zoomLevel = pnewvalue;
		
        MyTransform.localScale = new Vector3(zoomLevel, zoomLevel, 1);
    }

    private void Finish()
    {
        // This only runs when the tween animated value is finished
    }
}
