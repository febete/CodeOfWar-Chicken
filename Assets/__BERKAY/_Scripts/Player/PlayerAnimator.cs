using System;
using UnityEngine;

namespace Berkay
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rb;
        

        private void Update()
        {
            SetSpeed();
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("basıldı spacee");
                animator.SetBool("isDead", true);
               
            }
        }

        private void SetSpeed()
        {
            var sp = rb.velocity.magnitude;
            animator.SetFloat("speed", sp);
        }

        public void StartDying()
        {
            Debug.Log("anomatöre girdi");
            animator.SetBool("isDead", true);
        }

    }
}