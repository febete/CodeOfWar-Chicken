using System;
using Cinemachine;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Berkay
{
    public enum PlayerState
    {
        Normal,
        Eating
    }
    
    public class PlayerMovement : MonoBehaviour
    {
        [Foldout("References")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private ChickenStatSO playerData;
        [SerializeField] private CinemachineVirtualCamera wormCamera;
        
        public PlayerState PlayerState;
        private static Transform EatWorm;
        private float MoveSpeed => playerData.MoveSpeed;
        private float eatSpeed => MoveSpeed / 2.5f;
        private float speed;
        
        public bool isMain = false;
        
        
        

        private void Start()
        {
            PlayerState = PlayerState.Normal;
        }

        private Vector3 Direction => new (
            InputCanvas.Instance.HorizontalInp,
            0,
            InputCanvas.Instance.VerticalInp);
        
        private void Update()
        {
            if (isMain )
            {
                Move();

                if (PlayerState == PlayerState.Eating)
                {
                    wormCamera.Priority = 11;
                    speed = eatSpeed;
                }
                else
                {
                    wormCamera.Priority = 9;
                    speed = MoveSpeed;
                }
            }
            
            /*else
            {
                RotateFace();
            }*/
        }
        
        private void Move()
        {
            if (HealthController.health <= 0)
            {
                rb.velocity = Vector3.zero;
                return;
            }
            
            rb.velocity = Direction * speed;            
            RotateFace();
        }
        
        private void RotateFace()
        {
            if (PlayerState == PlayerState.Normal && isMain)
            {
                
                var angle = Mathf.Atan2(InputCanvas.Instance.HorizontalInp, InputCanvas.Instance.VerticalInp) * Mathf.Rad2Deg;
                var rotationVector = new Vector3(0, angle, 0);
                var targetRot = Quaternion.Euler(rotationVector);
                
                if (angle != 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 25f);
                }
            }

            if (PlayerState == PlayerState.Eating)
            {
                transform.LookAt(EatWorm);
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HoleController holeController))
            {
                EatWorm = holeController.playerLookTransform;
                PlayerState = PlayerState.Eating;
            }
        }
    }
}