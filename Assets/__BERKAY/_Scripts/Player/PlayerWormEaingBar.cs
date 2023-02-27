using System;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWormEaingBar : MonoBehaviour
{
    [SerializeField] private Canvas eatCanvas;
    [SerializeField] private Point dot;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Image fillImage;
    
    
    
    private Vector3 startRotation;
    private Vector3 openedPos;
    private void Start()
    {
        startRotation = eatCanvas.transform.localRotation.eulerAngles;
    }

    

    private void Update()
    {
        if (playerMovement.PlayerState == PlayerState.Eating)
        {
            eatCanvas.gameObject.SetActive(true);
            dot.gameObject.SetActive(true);
            
            fillImage.fillAmount = Vector3.Distance(dot.enablePos, dot.transform.position);

        }
        else
        {
            eatCanvas.gameObject.SetActive(false);
            dot.gameObject.SetActive(false);
        }
        
        eatCanvas.transform.rotation = Quaternion.Euler(startRotation);
    }
}
