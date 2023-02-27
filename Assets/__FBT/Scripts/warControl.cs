using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;

public enum WarriorState
{
    GoingToWaitArea,
    Waiting,
    Fighting,
}

public class warControl : MonoBehaviour
{
    private WarriorState warriorState;

    [SerializeField] private SoldireHolder _SoldireHolder;

    public warriorChıckenSO _warriorChickenSO;
    public lvlControl lvlControl;
    public enemyInformation enemyInformation;

    NavMeshAgent nMesh;
    
   
    public Transform _gunPlace;
    Transform _tempPosition;
    
    

    bool light_contact;
    public bool _shoot =false;

    public GameObject _activeGun;
    
    public List<GameObject> _AllEnemies;
    
    public GameObject NearestOBJ;
    float _distance;
    public float _nearestDistance=10000;
    float amount ;                                       //enemy den alması gerekiyor

    public float _jumpPower;
    public int _jumpCount;
    float _duration;

    public float _health_warriorChicken;
    public float _totalHealth_warriorChicken;
    [SerializeField] private GameObject rifle;
    


    
    float z;
    bool isDone = false;
    private bool isLevel1;
    
    [SerializeField] private WarriorChickenAnimationController warriorChickenAnimationController;
    

    private void Awake()
    {
        _warriorChickenSO = _SoldireHolder.getLevel();

        if (_warriorChickenSO.gun.tag == "Bullet")
        {
            rifle.SetActive(true);

        }

        if (_warriorChickenSO.level == 1)
        {
            isLevel1 = true;
        }
        else
        {
            isLevel1 = false;
        }
        
        this._health_warriorChicken = _warriorChickenSO.health_warriorChicken;
        this._totalHealth_warriorChicken = _warriorChickenSO.totalHealth_warriorChicken;
        this._duration = _warriorChickenSO.shootingRange;

        

        
    }

    void OnEnable()
    {

        warriorState = WarriorState.GoingToWaitArea;

        nMesh = GetComponent<NavMeshAgent>();
        _AllEnemies = lvlControl.listOfallEnemy;
        NearestOBJ = null;
        
        lvlControl.listOfallWarriorChicken.Add(gameObject);
    }
    

    void Update()
    {

        if(warriorState ==WarriorState.GoingToWaitArea)
        {
            //Bekleme noktasına git
            warriorChickenAnimationController.StartRun();

            if (isDone != true)
            {
                goWaiting();
                isDone = true;
            }


        }
        else if( warriorState == WarriorState.Waiting)
        {
            warriorChickenAnimationController.StartIdle();
            this.transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z+1));
        }
        else if(warriorState == WarriorState.Fighting)
        {
            attack();
        }
        
        
    }



    public void goWaiting()
    {

        int idx = lvlControl.listOfallWarriorChicken.IndexOf(this.gameObject);
        nMesh.destination = SoliderWaitArea.soliderPositions[idx];
        Debug.Log( idx+" : "+SoliderWaitArea.soliderPositions[idx]);
        
    }




    public void attack()
    {
        
        for (int i=0;i<_AllEnemies.Count;i++)
        {
            _distance = Vector3.Distance(this.transform.position, _AllEnemies[i].transform.position);

            if(_distance < _nearestDistance)
            {
               
                NearestOBJ = _AllEnemies[i];
                _nearestDistance = _distance;
            }

        }

        if( NearestOBJ!=null )
        {
            nMesh.stoppingDistance = 2f;
            nMesh.destination = NearestOBJ.transform.position;

        }
        else
        {
            _nearestDistance = 10000;
        } 

    }



    public void stateOfWar()
    {
        warriorState = WarriorState.Fighting;

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="EnemyArea" )
        {
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                other.gameObject.transform.GetChild(i).GetComponent<enemyInformation>()._counterattack = true;
            }


            StartCoroutine(createGun(_warriorChickenSO.fireWaitTime));
            //InvokeRepeating("fire", 2, 2);

        }

        if (other.gameObject.tag == "EnemyStone" && this.gameObject != null)
        {
            this.amount = other.gameObject.transform.parent.GetComponentInParent<enemyInformation>().enemySO.amountofDamage;

            other.gameObject.SetActive(false);
            reduceHealth(amount, other.gameObject);

        }

        if (other.gameObject.tag == "BulletEnemy" && this.gameObject != null)
        {
            this.amount = other.gameObject.transform.parent.GetComponentInParent<enemyInformation>().enemySO.amountofDamage;
            
            other.gameObject.SetActive(false);
            reduceHealth(amount, other.gameObject);

        }


    }



    public void reduceHealth(float amount, GameObject stone)
    {

        Debug.Log("Current: "+ _health_warriorChicken + " amount = " + amount);

        _health_warriorChicken -= amount;  //amount kadar can� azalt
        
        if (_health_warriorChicken <= 0)
        {

            //stone.transform.parent.GetComponent<warControl>()._shoot = false;
            stone.transform.parent.GetComponent<enemyInformation>()._nearestDistance = 10000;

            lvlControl.listOfallWarriorChicken.Remove(this.gameObject);   //listeden de siliyor sahneden silince
            warriorChickenAnimationController.StartDying();

            //this.gameObject.SetActive(false);
        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnemyArea")
        {
            //nMesh.destination = this.transform.position;
            _shoot = true;
            if(NearestOBJ!=null)
            {
                _tempPosition = NearestOBJ.transform;
            }else
            {
                //Ayn� objeye en yak�n oldu�u ba�ka tavuk avrsa ve o tavuk bu tavuktan�nce �ld�rm��se en yak�n objesi null oluyor ve hata veriyor.
                //
                //attack();
                _nearestDistance = 10000;

            }

        }
    }

   


    public IEnumerator createGun(float waitTime)
    {
        warriorChickenAnimationController.StartFire(isLevel1);
        
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if (_activeGun == null && NearestOBJ != null)
            {
                string nameOfActiveGun = _warriorChickenSO.gun.gameObject.tag;

                if (nameOfActiveGun == "Stone")
                {

                    _activeGun = Instantiate(_warriorChickenSO.gun, _gunPlace.transform.position,
                        _gunPlace.transform.rotation, transform);
                    var targetPosition = NearestOBJ.transform.position;
                    _activeGun.transform.DOJump(targetPosition, _jumpPower, _jumpCount, _duration);
                    Destroy(_activeGun, _duration + 0.1f);
                }
                else if (nameOfActiveGun == "Bullet")
                {
                    _activeGun = Instantiate(_warriorChickenSO.gun, _gunPlace.transform.position,
                        _gunPlace.transform.rotation, transform);
                    var targetPosition = NearestOBJ.transform.position;
                    var newTarget = new Vector3(targetPosition.x, targetPosition.y + .5f, targetPosition.z);
                    _activeGun.transform.DOMove(newTarget, _duration);
                    Destroy(_activeGun, _duration + 0.1f);
                }

            }
        }


    }
 

   

  
}
