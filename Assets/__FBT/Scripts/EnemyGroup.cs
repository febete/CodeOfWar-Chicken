using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
     public bool isAlive;
    void Start()
    {
        isAlive = true;
    }

    private void Update()
    {
        if(transform.childCount==0)
        {
            isAlive = false;
        }
    }
}
