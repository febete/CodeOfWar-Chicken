using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Berkay
{
    public class PlayerStackBag : MonoBehaviour
    {
        [SerializeField] private Transform stackPoint;
        
        private readonly Vector3 stackOffset = new Vector3(0, 0.22f, 0);
        public static readonly List<IStackable> Bag = new List<IStackable>();

        private Coroutine c1;
        private Coroutine c2;

        private void Update()
        {
            MoveStackedObjects();
        }

        public Vector3 GetStackPos()
        {
            return stackPoint.position + (stackOffset * Bag.Count);
        }

        private void MoveStackedObjects()
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                Bag[i].Follow(stackPoint.position + (stackOffset * i), .05f * i);
            }
        }

        private void PutEggsToPlaces(List<Transform> list, bool isSolider)
        {
            for (int i = 0; i < list.Count; i++)   
            {
                if (Bag.Count == 0) return;
                
                if (Bag[^(1)] is not MonoBehaviour obj) return;

                if (isSolider)
                {
                    obj.GetComponent<Egg>().isSolider = true;
                }

                obj.transform.DOJump(list[i].transform.position, 1f,1,0.5f);
                Bag.Remove((IStackable) obj);

            }
        }

        private IEnumerator PutEggsOneByOne(List<Transform> list, bool isSolider)
        {
            int counter = 0;
            while (true)
            {
                yield return new WaitForSeconds(.3f);
                if (Bag.Count == 0) yield break;

                if (Bag[^(1)] is not MonoBehaviour obj) yield break;

                if (isSolider)
                {
                    obj.GetComponent<Egg>().isSolider = true;
                }

                obj.GetComponent<CapsuleCollider>().isTrigger = false;
                obj.transform.DOJump(list[counter].transform.position, 1f, 1, 0.5f);
                Bag.Remove((IStackable) obj);
                counter++;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("WorkerA"))
            {
                c1 = StartCoroutine(PutEggsOneByOne(WorkerIntubation.WorkerEggPlaces, false));
            }
            else if (other.CompareTag("SoliderA"))
            {
                c2= StartCoroutine(PutEggsOneByOne(SoliderIntubation.SoliderEggPlaces, true));
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("WorkerA"))
            {
                StopCoroutine(c1);
            }
            else if (other.CompareTag("SoliderA"))
            {
                StopCoroutine(c2);
            }
        }
        
    }
}