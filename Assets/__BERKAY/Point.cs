using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector3 enablePos;

    private void OnEnable()
    {
        enablePos = transform.position;
    }

    private void OnDisable()
    {
        enablePos = Vector3.zero;
    }
}
