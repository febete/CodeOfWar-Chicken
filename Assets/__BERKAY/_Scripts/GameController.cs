using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int FPS;
    
    private void Start()
    {
        Application.targetFrameRate = FPS;
    }
}
