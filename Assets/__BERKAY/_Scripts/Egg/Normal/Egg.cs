using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Berkay
{
    public class Egg : MonoBehaviour, IStackable
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private BreakableEgg breakableEgg;

        private bool isStarted = false;
        private bool isStacked = false;
        public bool isSolider = false;

        private Tween tween;
        
        private void Update()
        {
            Replace();
        }

        public void GetStack(Vector3 targetPos)
        {
            if (isStacked) {return;}
            isStacked = true;
            
            transform.DOMove(targetPos, 0.2f).OnComplete(() =>
            {
                PlayerStackBag.Bag.Add(this);
            });

            CloseConstrains();
            transform.DORotate(new Vector3(0, 0, 0), 0.2f).OnComplete(() =>
            {
                
            });
        }

        public void Follow(Vector3 followPos, float duration)
        {
            tween = transform.DOMove(followPos, duration);
            StartCoroutine(KillTween(tween));
        }

        private IEnumerator KillTween(Tween tween)
        {
            yield return new WaitForSeconds(0.1f);
            tween.Kill();
        }

        public void CloseConstrains()
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
        public void GetProduced(Vector3 instantiatePos, Vector3 startDropPos)
        {
            Egg egg = Instantiate(this, instantiatePos, Quaternion.identity);
            egg.transform.DOMove(startDropPos, 1f).OnComplete(() =>
            {
                egg.rb.useGravity = true;
            });
        }

        private bool IsEggInBag()
        {
            if (PlayerStackBag.Bag.Contains(this))
            {
                return true;
            }

            return false;
        }

        private void Replace()
        {
            if (IsEggInBag() && !isStarted)
            {
                isStarted = true;
                StartCoroutine(ReplaceWithBreakable());
            }
        }

        private IEnumerator ReplaceWithBreakable()
        {
            while (true)
            {
                yield return new WaitForSeconds(8f);
                
                if (!PlayerStackBag.Bag.Contains(this))
                {
                    var obj = Instantiate(breakableEgg, transform.position, Quaternion.identity);
                    if (isSolider)
                    {
                        obj.isSolider = true;
                    }
                    Destroy(gameObject);
                }
            }
        }
        
    }
}