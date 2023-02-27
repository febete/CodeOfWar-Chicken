using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Enemy" , menuName ="Enemy")]
public class EnemySO : ScriptableObject
{
    public float health_Enemy ;
    public float totalHealth_Enemy;
    public float amountofDamage;
    public float shootingRange; //atýþ hýzý

    public GameObject gun;

    
}
