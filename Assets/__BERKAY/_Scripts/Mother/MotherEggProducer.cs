using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Berkay
{ 
    public class MotherEggProducer : MonoBehaviour
    {
        [SerializeField] private Egg egg;
        [SerializeField] private Transform instantiatePos;
        [SerializeField] private Transform startDropPos;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MotherController.MotherState = MotherState.Producing;
            }
        }

        public void ProduceEgg()
        {
            var randomZoffset = Random.Range(-0.1f, -0.5f);
            var pos = new Vector3(startDropPos.position.x, startDropPos.position.y,
                startDropPos.position.z + randomZoffset);
            
            egg.GetProduced(instantiatePos.position, pos);
            
        }

        public void FinishProducing()
        {
            MotherController.MotherState = MotherState.Waiting;
        }

    }
}