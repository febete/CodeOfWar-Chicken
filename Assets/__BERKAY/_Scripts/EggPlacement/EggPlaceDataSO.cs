using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stat File", menuName = "Stat/Egg Place Stat")]
public class EggPlaceDataSO : ScriptableObject
{
    [Range(1, 12), SerializeField] private int slotCount;
    public int SlotCount => slotCount;

    [Range(5, 30), SerializeField] private float breakTime;
    public float BreakTime => breakTime;

    [SerializeField] private GameObject productType;
    public GameObject ProductType => productType;
    
}
