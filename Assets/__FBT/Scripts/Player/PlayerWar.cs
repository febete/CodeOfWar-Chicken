using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Berkay;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWar : MonoBehaviour
{
    public List<GameObject> _AllEnemies;

    public lvlControl lvlControl;
    
    float amountOfDamage;
    float _distance;
    float _nearestDistance = 10000;

    public float fireWaitTime;
    public float _duration;

    public Transform _gunPlace;

    public GameObject gun;
    public GameObject NearestOBJ;

    public Image healthBar;

    [SerializeField] private GameObject rifle;
    [SerializeField] private PlayerAnimationController PlayerAnimationController;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        _AllEnemies = lvlControl.listOfallEnemy;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AllEnemyArea") && lvlControl.listOfallWarriorChicken.Count == 1)
        {
            foreach (var gameObj in lvlControl.listOfallWarriorChicken)
            {
                if(gameObj.CompareTag("Player"))
                {
                    rifle.SetActive(true);

                    PlayerAnimationController.StartFire();

                    //en yak�n enemy yi bulmas� gerekiyor
                    attack();

                    //player silahlan�p vurmaya ba�lamas� gerek
                    StartCoroutine(createGun(fireWaitTime));




                }
            }

           
        }


        if (other.CompareTag("EnemyStone"))
        {
            //ta� �arp�yor
            amountOfDamage = other.gameObject.transform.parent.GetComponentInParent<enemyInformation>().enemySO.amountofDamage;

            if (HealthController.health > 0)
            {
                ReduceHealth(amountOfDamage);
            }
        }


        if(other.CompareTag("BulletEnemy"))
        {
            //silah �arp�yor.
            amountOfDamage = other.gameObject.transform.parent.GetComponentInParent<enemyInformation>().enemySO.amountofDamage;

            if (HealthController.health > 0)
            {
                ReduceHealth(amountOfDamage);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("AllEnemyArea"))
        {
            PlayerAnimationController.StartIdle();
            rifle.SetActive(false);
            NearestOBJ = null;
            
        }
       
        
    }

    

    public void ReduceHealth(float amount)
    {
        
        HealthController.TakeDamage(amount);
        

        if(HealthController.health <= 0)
        {
            lvlControl.listOfallWarriorChicken.Remove(gameObject);
            PlayerAnimationController.StartDying();
            transform.DOScale(new Vector3(.1f,.1f,.1f), 2f).SetEase(Ease.InBack).OnComplete(() =>
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                transform.position = startPos;
                PlayerAnimationController.SpawnAnim();
                _nearestDistance = 10000;
                transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                    HealthController.RespawnHealth();
                });
            });

        }
    }
    

    public void attack()
    {
        for (int i = 0; i < _AllEnemies.Count; i++)
        {
            _distance = Vector3.Distance(this.transform.position, _AllEnemies[i].transform.position);

            if (_distance < _nearestDistance)
            {

                NearestOBJ = _AllEnemies[i];
                _nearestDistance = _distance;
            }

        }

        if (NearestOBJ == null)
        {
            _nearestDistance = 10000;
        }
    }




    public IEnumerator createGun(float waitTime)
    {
       

        yield return new WaitForSeconds(waitTime);
        if (NearestOBJ != null)
        {


            var _activeGun = Instantiate(gun, _gunPlace.transform.position,
                _gunPlace.transform.rotation, transform);


            var newRotation = Quaternion.LookRotation( NearestOBJ.transform.position - transform.position);
            transform.DORotateQuaternion(newRotation, .5f);
            gun.transform.DORotateQuaternion(newRotation, .1f);


            var targetPosition = NearestOBJ.transform.position;
            var newTarget = new Vector3(targetPosition.x, targetPosition.y + .5f, targetPosition.z);
            _activeGun.transform.DOMove(newTarget, _duration);
            Destroy(_activeGun, _duration + 0.1f);


        }


    }

}
