using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject playerMenu,chickenMenu,incubationMenu;
    [SerializeField] private RectTransform playerActive, playerDeactive, chickenActive, chickenDeactive, incubationActive, incubationDeactive;

    
    public void ActivatePlayer()
    {
        var pos = playerDeactive.position;
        playerDeactive.DOMove(playerActive.position, .5f).OnComplete(() =>
        {
            playerMenu.SetActive(true);
            chickenMenu.SetActive(false);
            incubationMenu.SetActive(false);
            
            chickenActive.gameObject.SetActive(false);
            chickenDeactive.gameObject.SetActive(true);
            
            incubationActive.gameObject.SetActive(false);
            incubationDeactive.gameObject.SetActive(true);
            
            playerActive.gameObject.SetActive(true);
            playerDeactive.position = pos;
            playerDeactive.gameObject.SetActive(false);
        });
    }
    
    public void ActivateChicken()
    {
        var pos = chickenDeactive.position;
        chickenDeactive.DOMove(chickenActive.position, .5f).OnComplete(() =>
        {
            playerMenu.SetActive(false);
            chickenMenu.SetActive(true);
            incubationMenu.SetActive(false);
            
            playerActive.gameObject.SetActive(false);
            playerDeactive.gameObject.SetActive(true);
            
            incubationActive.gameObject.SetActive(false);
            incubationDeactive.gameObject.SetActive(true);
            
            chickenActive.gameObject.SetActive(true);
            chickenDeactive.position = pos;
            chickenDeactive.gameObject.SetActive(false);
        });
    }
    
    public void ActivateIncubation()
    {
        var pos = incubationDeactive.position;
        incubationDeactive.DOMove(incubationActive.position, .5f).OnComplete(() =>
        {
            playerMenu.SetActive(false);
            chickenMenu.SetActive(false);
            incubationMenu.SetActive(true);
            
            playerActive.gameObject.SetActive(false);
            playerDeactive.gameObject.SetActive(true);
            
            chickenActive.gameObject.SetActive(false);
            chickenDeactive.gameObject.SetActive(true);
            
            incubationActive.gameObject.SetActive(true);
            incubationDeactive.position = pos;
            incubationDeactive.gameObject.SetActive(false);
        });
    }
}
