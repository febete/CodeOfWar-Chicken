using UnityEngine;

namespace Berkay
{
    public enum MotherState
    {
        Waiting,
        Producing
    }
    
    public class MotherController : MonoBehaviour
    {
        public static MotherState MotherState = MotherState.Waiting;
        public Transform motherBeak;
        public static void StartProducing()
        {
            MotherState = MotherState.Producing;
        }
        
    }
}