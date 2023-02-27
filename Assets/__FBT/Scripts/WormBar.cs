using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormBar : MonoBehaviour
{
    [SerializeField] private Image WormBarSprite;
    [SerializeField] private float reduceSpeed = 2;
    private float _target;

   
    public void updateWormBar(float maxWorm,float currentWorm)
    {
        //WormBarSprite.fillAmount = currentWorm / maxWorm;,
        _target= currentWorm / maxWorm;
    }

    private void Update()
    {
        //WormBarSprite.fillAmount = Mathf.MoveTowards(WormBarSprite.fillAmount, _target, reduceSpeed * Time.deltaTime);
        WormBarSprite.fillAmount = Mathf.Lerp(WormBarSprite.fillAmount, _target, reduceSpeed * Time.deltaTime);
    }

}
