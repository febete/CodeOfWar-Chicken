using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Warrior Chicken", menuName = "WarriorChicken")]
public class warriorChıckenSO : ScriptableObject
{
    public int level;
    public float health_warriorChicken;
    public float totalHealth_warriorChicken;
    public float amountofDamage;
    public float shootingRange; //atış hızı
    public float fireWaitTime;
    
    public GameObject gun;
}
