using System;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using UnityEngine;

public class SoliderIntubation : MonoBehaviour
{
    [SerializeField] private Transform[] soliderPlaces;
    [SerializeField] private EggPlaceDataSO data;
    public static  List<Transform> SoliderEggPlaces = new List<Transform>(); public int MaxEggCount => data.SlotCount;
    public int CurrentEggCount = 0;
   
    private void Awake()
    {
        InitArea();
    }
    
    private void InitArea()
    {
        foreach (var place in soliderPlaces)
        {
            if (place == null)
            {
                return;
            }
            SoliderEggPlaces.Add(place);
        }
    }
}
    
    
    
    

