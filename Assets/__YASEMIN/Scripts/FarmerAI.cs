using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public enum FarmerState
{
    StealChicken,
    WalkOut
}


public class FarmerAI : MonoBehaviour
{

    //[SerializeField] public Transform Stickman_Hat;

    private Transform target;
    public FarmerState farmerState;

    private Transform exitTransform;
    Seeker seeker;
    Rigidbody _rb;
    void Start()
    {

        farmerState = FarmerState.StealChicken;
        exitTransform = GameObject.FindGameObjectWithTag("exit").transform;
        seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody>();

        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
    }
    public void UpdatePath()
    {

        if(farmerState == FarmerState.StealChicken)
        {
            if (seeker.IsDone())
            {
                target = GameObject.FindGameObjectWithTag("WorkerChicken").transform;
                seeker.StartPath(_rb.position, target.position);
            }
        }

        if(farmerState == FarmerState.WalkOut)
        {
            seeker.StartPath(_rb.position, exitTransform.position);
        }
              
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WorkerChicken")
        {
            //other.transform.position = Stickman_Hat.position;
            Destroy(other);
            farmerState = FarmerState.WalkOut;
        }
    }

}
