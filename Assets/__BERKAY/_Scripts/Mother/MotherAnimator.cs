using System;
using UnityEngine;

namespace Berkay
{
    public class MotherAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Update()
        {
            ControlAnimations();
        }

        private void ControlAnimations()
        {
            if (MotherController.MotherState == MotherState.Waiting)
            {
                animator.SetBool("isProducing", false);
            }
            else if (MotherController.MotherState == MotherState.Producing)
            {
                animator.SetBool("isProducing", true);
            }
        }
        
    }
}