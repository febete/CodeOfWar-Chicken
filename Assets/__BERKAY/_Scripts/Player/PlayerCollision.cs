using System;
using UnityEngine;

namespace Berkay
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private PlayerStackBag playerStackBag;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IStackable stackable))
            {
                stackable.GetStack(playerStackBag.GetStackPos());
                //collision.collider.isTrigger = true;
            }
        }
    }
}