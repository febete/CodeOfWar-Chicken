using System;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOpener : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private GameObject upgradeCanvas;
    private Tween tween;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            tween = fillImage.DOFillAmount(1, 0.5f).OnComplete(() =>
            {
                upgradeCanvas.SetActive(true);
                upgradeCanvas.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InElastic);
            });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tween.Kill();
        upgradeCanvas.SetActive(false);
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            fillImage.DOFillAmount(0, 0.5f);
        }
    }

    public void CloseUpgradeCanvas()
    {
        upgradeCanvas.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InElastic).OnComplete(() =>
        {
            upgradeCanvas.SetActive(false);
        });
    }
}
