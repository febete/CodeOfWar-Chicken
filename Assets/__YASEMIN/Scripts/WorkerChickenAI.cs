using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public enum WorkerState
{
    GoingWorm,
    GoingMother
}

public class WorkerChickenAI : MonoBehaviour
{



    
    
    public HoleController target;
    public WorkerState workerState;

    private Transform motherTransform;

    Seeker seeker;
    [SerializeField] Rigidbody _rb;

    

    void Start()
    {
        workerState = WorkerState.GoingWorm;
        motherTransform = GameObject.Find("AreaWormTransfer").transform;
        seeker = GetComponent<Seeker>();
    }

    private void Update()
    {
        
        if (target == null || target.isDestroyed)
        {
            UpdatePath();
        }

        if (target != null && target.isTargeted)
        {
            UpdatePath();
        }

        if (_rb)
        {
            
        }
    }

    public void UpdatePath()
    {
        if (workerState == WorkerState.GoingWorm)
        {
            foreach (var hole in WromAreaInitilazior.ActiveHoles)
            {
                if (!hole.isTargeted)
                {
                    if (seeker.IsDone() || target == null)
                    { 
                        target = hole;
                        hole.isTargeted = true;
                        seeker.StartPath(_rb.position, target.transform.position);
                    }
                }
            }
        }

        if (workerState == WorkerState.GoingMother)
        {
            seeker.StartPath(_rb.position, motherTransform.position);
        }
    }
    
    
    
    
    
    
}
