using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closestDistance : MonoBehaviour
{
    public GameObject[] AllEnemies;
    public GameObject NearestOBJ;
    float _distance;
    float _nearestDistance = 1000;

    public GameObject closestObject()
    {
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < AllEnemies.Length; i++)
        {
            _distance = Vector3.Distance(this.transform.position, AllEnemies[i].transform.position);

            if (_distance < _nearestDistance)
            {
                NearestOBJ = AllEnemies[i];
                _nearestDistance = _distance;
            }
        }

        return NearestOBJ;
    }
}
