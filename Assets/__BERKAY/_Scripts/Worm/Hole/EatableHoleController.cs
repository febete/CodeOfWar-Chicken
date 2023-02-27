using System;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using UnityEngine;


public enum EatState
{
    Pulling,
    Eated
}
public class EatableHoleController : MonoBehaviour
{
    public EatState eatState;
    [SerializeField] private float eatDistance;
    [SerializeField] private Transform head;
    [SerializeField] private Transform body;
    [SerializeField] private HoleController holeController;
    private WromAreaInitilazior wromAreaInitilazior;
    private bool isRoutineCalled = false;
    
    private Transform beak;
    private bool isEntered = false;
    public bool isGoingMother = false;

    private void OnEnable()
    {
        beak = holeController.triggeredBeak;
        eatState = EatState.Pulling;
        wromAreaInitilazior = GameObject.FindObjectOfType<WromAreaInitilazior>();
    }

    private void Update()
    {
        if (isGoingMother)
        {
            return;
        }
        
        IsEated();
        if (beak == null)
        {
            beak = holeController.triggeredBeak;
        }
        
        if (eatState == EatState.Pulling)
        {
            head.position = beak.position;
        }

        if (eatState == EatState.Eated)
        {
            head.position = beak.position;
            body.position = Vector3.Lerp(body.position, head.position, 0.5f);
            transform.SetParent(beak);
            if (!isRoutineCalled)
            {
                StartCoroutine(wromAreaInitilazior.DirectKill(holeController));
                isRoutineCalled = true;
            }
        }
    }

    
    private void IsEated()
    {

        if (isEntered)
        {
            return;
        }
        
        if (Math.Abs(Vector3.Distance(head.position, body.position)) > eatDistance)
        {
            //Debug.Log("GİRDİM");
            eatState = EatState.Eated;
            isEntered = true;
        }
        else
        {
            eatState = EatState.Pulling;
        }

    }

    public void AddMe(List<GameObject> list)
    {
        list.Add(gameObject);
    }
}
