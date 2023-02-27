using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berkay;
using DG.Tweening;


public class WormEater : MonoBehaviour
{
    public List<GameObject> WormsInMount = new List<GameObject>();
    public List<GameObject> FakeWorms = new List<GameObject>();
    [SerializeField] private GameObject fakeWorm;
    [SerializeField] public Transform beak;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform fakeWormParent;
    
    public int counter = 0;
    
    
    private void Update()
    {
        if (beak.childCount > counter)
        {
            var f = Instantiate(fakeWorm, beak.position, Quaternion.identity,fakeWormParent);
            f.SetActive(false);
            FakeWorms.Add(f);
            playerMovement.PlayerState = PlayerState.Normal;
            counter++;
        }
    }

    public void SendWormsToMother(Transform motherTransform)
    {
        foreach (var VARIABLE in WormsInMount)
        {
            Destroy(VARIABLE.gameObject);
        }

        counter = 0;

        foreach (var VARIABLE in FakeWorms)
        {
            VARIABLE.transform.parent = null;
            VARIABLE.SetActive(true);
            VARIABLE.transform.DOMove(motherTransform.position, 0.5f).OnComplete(() =>
            {
                FakeWorms.Remove(VARIABLE);
                Destroy(VARIABLE.gameObject);
            });
        }
    }
    
}
