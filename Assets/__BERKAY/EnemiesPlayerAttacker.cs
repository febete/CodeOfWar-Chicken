using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPlayerAttacker : MonoBehaviour
{
    private void Update()
    {
        //Debug.Log(lvlControl.listOfallWarriorChicken.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && lvlControl.listOfallWarriorChicken.Count == 0)
        {
            //Debug.Log("GİRDİM");
            lvlControl.listOfallWarriorChicken.Add(other.gameObject);

            foreach (var enemy in lvlControl.listOfallEnemy)
            {
                enemy.GetComponent<enemyInformation>()._counterattack = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //Debug.Log("CIKTIM");
            lvlControl.listOfallWarriorChicken.Remove(other.gameObject);
            
            foreach (var enemy in lvlControl.listOfallEnemy)
            {
                enemy.GetComponent<enemyInformation>()._counterattack = false;
                enemy.GetComponent<enemyInformation>().GoWait();
                enemy.GetComponent<enemyInformation>().SetIdleAnim();
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && lvlControl.listOfallWarriorChicken.Count == 0)
        {
            lvlControl.listOfallWarriorChicken.Add(other.gameObject);
            
            foreach (var enemy in lvlControl.listOfallEnemy)
            {
                enemy.GetComponent<enemyInformation>()._counterattack = true;
            }
        }
    }
}
