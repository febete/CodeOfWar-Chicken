using System.Collections;
using System.Collections.Generic;
using Berkay;
using DG.Tweening;
using FIMSpace;
using UnityEngine;
using UnityEngine.UI;

public class WormTrans : MonoBehaviour
{/*
    [SerializeField] private float _maxWorm =5;
    private WormBar _wormBar;
    private float _currentWorm;
    public int wormCount;
    

    private Image slider_TransferArea;

    void Start()
    {
        _wormBar = GameObject.Find("WormBar Canvas").GetComponent<WormBar>();
        slider_TransferArea = GameObject.Find("imgFilled").GetComponent<Image>();
        _currentWorm = 0;
        _wormBar.updateWormBar(_maxWorm, _currentWorm);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "WormTransferField" && gameObject.TryGetComponent(out PlayerWormEater playerWormEater) )
        {
            slider_TransferArea.DOFillAmount(1, 1f);

            wormCount = playerWormEater.WormsInMount.Count;
            if (wormCount>0)
            {
                StartCoroutine(PlayerEatWorm(wormCount, playerWormEater));
                wormCount = 0;
            }
            
        }
        
        if (other.gameObject.tag == "WormTransferField" && gameObject.TryGetComponent(out WorkerWormEater workerWormEater) )
        {
            
            slider_TransferArea.DOFillAmount(1, 1f);

            wormCount = workerWormEater.WormsInMount.Count;
            if (wormCount>0)
            {
                StartCoroutine(WorkerEatWorm(wormCount, workerWormEater));
                wormCount = 0;
            }

            if (gameObject.TryGetComponent(out WorkerChickenAI workerChickenAI ))
            {
                workerChickenAI.workerState = WorkerState.GoingWorm;
            }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WormTransferField")
        {
            slider_TransferArea.DOFillAmount(0, 1f);
        }
    }


    public IEnumerator PlayerEatWorm(float wCount, PlayerWormEater wormEater)
    {
        foreach (var worm in wormEater.WormsInMount)
        {
            Destroy(worm);
        }

        for (int i = 0; i < wCount; i++)
        {
            _currentWorm++;
            _wormBar.updateWormBar(_maxWorm, _currentWorm);
            Debug.Log("---" + _currentWorm + _maxWorm);

            if (_currentWorm == _maxWorm)
            {
                Debug.Log("girdim");


                _currentWorm = 0;
                yield return new WaitForSeconds(1f);
                _wormBar.updateWormBar(_maxWorm, _currentWorm);
                MotherController.StartProducing();
                yield return new WaitForSeconds(1f);

            }
        }
    }

    public IEnumerator WorkerEatWorm(float wCount, WorkerWormEater wormEater)
        {
            foreach (var worm in wormEater.WormsInMount)
            {
                Destroy(worm);
            }
            for (int i = 0; i < wCount; i++)
            {
                _currentWorm++;
                _wormBar.updateWormBar(_maxWorm, _currentWorm);
                Debug.Log("---" + _currentWorm + _maxWorm);
          
                if (_currentWorm == _maxWorm)
                {
                    Debug.Log("girdim");

        
                    _currentWorm = 0;
                    yield return new WaitForSeconds(1f);
                    _wormBar.updateWormBar(_maxWorm, _currentWorm);
                    MotherController.StartProducing();
                    yield return new WaitForSeconds(1f);

                }
            }
        }
        */

    

}
