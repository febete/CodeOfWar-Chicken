using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private enemyInformation info;
    
    
    public void StartIdle()
    {
        animator.SetBool("isFire", false);
        animator.SetBool("isWalkBack", false);
    }
    
    public void StartFire(bool isLevel1)
    {
        if (isLevel1)
        {
            animator.SetBool("isLevel1", true);
            animator.SetBool("isFire", true);
        }
        else
        {
            animator.SetBool("isLevel1", false);
            animator.SetBool("isFire", true);
        }
    }

    public void StartDying()
    {
        animator.SetBool("isDead", true);
    }

    public void FireForAnim()
    {
        //Debug.Log("ANİMATİON FİRE");
        info.createGun();
    }

    public void DieForAnim()
    {
        info.gameObject.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(info.gameObject);
        });
    }
}
