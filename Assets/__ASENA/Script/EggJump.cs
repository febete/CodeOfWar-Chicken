using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EggJump : MonoBehaviour
{
    public GameObject OB_Egg;

    void Start() 
    {
        transform.DOJump(transform.position, 1f, 3, 2f);
    }

    void Update()
    {
        
    }
}
