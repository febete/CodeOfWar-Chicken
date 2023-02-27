using System;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    public float SpawnRate;
    public float LifeTime;

    [SerializeField] private IdleHoleController idleHole;
    [SerializeField] private Transform eatableHoleTransform;
    [SerializeField] public EatableHoleController eatableHole;
    
    [SerializeField] private BoxCollider boxCollider;

    [SerializeField] public Transform playerLookTransform;

    public bool isDestroyed = false;
    public bool isTargeted = false;
    
    
    public Transform triggeredBeak;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("WorkerChicken"))
        {


            isTargeted = true;
            idleHole.gameObject.SetActive(false);
            eatableHoleTransform.gameObject.SetActive(true);

            if (other.gameObject.TryGetComponent(out WormEater wormEater))
            {
                triggeredBeak = wormEater.beak;
                eatableHole.AddMe(wormEater.WormsInMount);

                if (other.gameObject.TryGetComponent(out WorkerChickenAI workerChickenAI))
                {
                    workerChickenAI.workerState = WorkerState.GoingMother;
                    workerChickenAI.UpdatePath();
                }
            }





            boxCollider.enabled = false;
        }
    }

    public List<GameObject> TriggeredList(List<GameObject> list)
    {
        return list;
    }

    


}
