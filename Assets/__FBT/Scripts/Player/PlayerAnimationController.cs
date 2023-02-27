using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
   


    void Update()
    {
        
    }

    public void StartDying()
    {
        animator.SetBool("isDead", true);
    }

    public void StartFire()
    {
        animator.SetBool("isFire", true);
    }

    public void StartIdle()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isFire", false);
    }

    public void SpawnAnim()
    {
        //animator.Play("Spawn");
        animator.SetTrigger("Spawn");
        animator.SetBool("isDead", false);
    }

   

}
