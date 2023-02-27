using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
    private static bool isOpen = false;
    [SerializeField] private GameObject openImage;
    [SerializeField] private GameObject closeImage;
    
    public void ChangeVibration()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            openImage.SetActive(true);
            closeImage.SetActive(false);
            return;
        }
        openImage.SetActive(false);
        closeImage.SetActive(true);
    }

    public static void WeakVibrate()
    {
        if (!isOpen) return;
        //TODO VIBRATE WEAK
    }
    
    public static void MediumVibrate()
    {
        if (!isOpen) return;
        //TODO VIBRATE MID
    }
    
    public static void StrongVibrate()
    {
        if (!isOpen) return;
        //TODO VIBRATE STRONG
    }
}
