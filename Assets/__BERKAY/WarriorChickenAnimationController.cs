using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WarriorChickenAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private warControl war;
    
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

    public void StartRun()
    {
        animator.SetBool("isFire", false);
        animator.SetBool("isRun", true);
    }

    public void StartIdle()
    {
        animator.SetBool("isIdle", true);
    }

    public void DyingForAnim()
    {
        war.gameObject.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(war.gameObject);
        });
    }

}
