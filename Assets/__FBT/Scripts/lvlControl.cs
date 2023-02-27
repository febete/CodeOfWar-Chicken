using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvlControl : MonoBehaviour
{
    public GameObject[] allEnemies;
    public GameObject[] allEnemyGroups;

    public static List<GameObject> listOfallEnemy;
    public static List<GameObject> listOfallWarriorChicken;
    public static List<GameObject> listOfAllEnemyGroups;

    private float maxEnemy;

    public Image LevelBar;


    private void Awake()
    {

        listOfallEnemy = new List<GameObject>();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in allEnemies)
        {
            listOfallEnemy.Add(obj);

        }


        maxEnemy = listOfallEnemy.Count;
        LevelBar.fillAmount = 1f;

        listOfAllEnemyGroups = new List<GameObject>();
        allEnemyGroups = GameObject.FindGameObjectsWithTag("EnemyArea");
        foreach (GameObject obj in allEnemyGroups)
        {
            listOfAllEnemyGroups.Add(obj);

        }



        listOfallWarriorChicken = new List<GameObject>();

    }


    private void Update()
    {
        UpdateLevelBar();

    }


    public void UpdateLevelBar()
    {
        LevelBar.fillAmount = listOfallEnemy.Count / maxEnemy;

        if (LevelBar.fillAmount == 0)
        {
            //Level completed
            //next level
        }
    }


}
