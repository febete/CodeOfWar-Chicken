using System;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using DG.Tweening;
using FIMSpace.FTail;
using UnityEngine;

public class WormTransferArea : MonoBehaviour
{
   [SerializeField] private MotherController motherController;
   
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.TryGetComponent(out WorkerChickenAI workerChickenAI))
      {
         workerChickenAI.workerState = WorkerState.GoingWorm;
         workerChickenAI.UpdatePath();
      }

      if (other.gameObject.TryGetComponent(out WormEater wormEater))
      {
         wormEater.SendWormsToMother(motherController.motherBeak);
      }
   }
}
