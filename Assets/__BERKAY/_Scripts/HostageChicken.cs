using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HostageChicken : MonoBehaviour
{
    [SerializeField] private EnemyGroup enemyGroup;
    [SerializeField] private Animator cageAnimator;
    [SerializeField] private Animator chickenAnimator;
    [SerializeField] private Transform chicken;
    [SerializeField] private Transform camera;
    
    
    private bool flag = true;

    private void Update()
    {
        OpenCage();
    }


    private void OpenCage()
    {
        if (!enemyGroup.isAlive && flag)
        {
            cageAnimator.SetBool("isFree", true);
            
            StartCoroutine(FlyRoutine());

            flag = false;
        }
    }

    private IEnumerator FlyRoutine()
    {
        yield return new WaitForSeconds(1f);
        chickenAnimator.SetBool("isFree", true);
        chicken.DOMove(camera.position, 3f);
        StartCoroutine(KillRoutine());
    }

    private IEnumerator KillRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
