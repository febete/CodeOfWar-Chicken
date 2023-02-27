using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableEgg : MonoBehaviour
{
    [SerializeField] private GameObject Solider;
    [SerializeField] private GameObject Worker;
    public bool isSolider;

    public void ProduceOnBreak()
    {
        if (isSolider)
        {
            Instantiate(Solider, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Worker, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
