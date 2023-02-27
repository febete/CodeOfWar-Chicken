using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IdleHoleController : MonoBehaviour
{
    [SerializeField] private Transform shakeTransform;
    [SerializeField] private Vector3 rotataAngle;
    [SerializeField] private float rotationDuration;
    
    private void Start()
    {
        shakeTransform.DORotate(rotataAngle, rotationDuration).SetLoops(-1, LoopType.Yoyo).From(-rotataAngle);
    }

    
}
