using UnityEngine;
using System.Collections.Generic;

public class WorkerIntubation : MonoBehaviour
{
    [SerializeField] private Transform[] workerPlaces;
    [SerializeField] private EggPlaceDataSO data;
    public static  List<Transform> WorkerEggPlaces = new List<Transform>();

    public int MaxEggCount => data.SlotCount;
    public int CurrentEggCount = 0;
   
    private void Awake()
    {
        InitArea();
    }
    
    private void InitArea()
    {
        foreach (var place in workerPlaces)
        {
            if (place == null)
            {
                return;
            }
            WorkerEggPlaces.Add(place);
        }
    }
} 