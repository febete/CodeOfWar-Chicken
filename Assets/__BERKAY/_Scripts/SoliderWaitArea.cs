using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoliderWaitArea : MonoBehaviour
{
    [SerializeField] private Transform firstSoliderPos;
    [SerializeField] private float xOffset, zOffset;
    [SerializeField] private GameObject sprite;
    
    public int maxSoliderNumber;
    public static List<Vector3> soliderPositions = new List<Vector3>();


    private void Start()
    {
        InitArea();
    }

    private void InitArea()
    {
        var pos = firstSoliderPos.position;
        
        
        for (int i = 0; i < maxSoliderNumber; i++)
        {
            var x = pos.x + (i % 5 * xOffset);
            var line = i / 5;
            float z = -line * zOffset + pos.z;

            var newPos = new Vector3(x, 0.1f, z);
            soliderPositions.Add(newPos);
            Instantiate(sprite, newPos, Quaternion.Euler(new Vector3(90, 0, 0)), transform);
        }
    }
}
    

