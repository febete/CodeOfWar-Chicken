using System.Collections;
using System.Collections.Generic;
using Berkay;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.AI;

public class enemyInformation : MonoBehaviour
{
    public EnemySO enemySO;
    public lvlControl lvlControl;
    private warControl warControl;
    [SerializeField] private EnemyAnimationController animationController;
    
    
    public Image HealtBar;

    public Canvas canvas_HealthBar;

    public float amount ;                 //solider chicken lardan almas� gerekiyor
    public float _health_Enemy;
    public float _totalHealth_Enemy;

    [SerializeField] private GameObject gun;
    
    public bool _counterattack = false;

    public List<GameObject> _AllWarriorChicken;
    float _distance;
    public float _nearestDistance = 10000;
    public GameObject NearestOBJ;
    public GameObject _activeGun;
  
    public Transform stonePlace;
    public Transform gunPlace;
    Transform _tempPosition;
    public float _jumpPower;
    public int _jumpCount;
    float _duration;

    public Vector3 startingPosition;
    public Vector3 startingRotation;
    private bool flag = true;
    
    
    NavMeshAgent nMesh;

    public void SetIdleAnim()
    {
        flag = true;
        animationController.StartIdle();
    }

    void Start()
    {
        HealtBar.fillAmount = enemySO.health_Enemy / enemySO.totalHealth_Enemy;
        this._health_Enemy = enemySO.health_Enemy;
        this._totalHealth_Enemy=enemySO.totalHealth_Enemy;
        this._duration = enemySO.shootingRange;
        

       
        _AllWarriorChicken = lvlControl.listOfallWarriorChicken;

        nMesh = GetComponent<NavMeshAgent>();

        //ba�lang�� pozisyonlar�
        startingPosition = gameObject.transform.position;
        //ba�lang�� rotasyonlar�
        startingRotation = transform.eulerAngles;

       
        if (enemySO.gun.tag == "BulletEnemy")
        {
            gun.SetActive(true);
        }
    }
  

    void Update()
    {

        counterAttack();
        
    }

    public void reduceHealth(float amount,GameObject stone)
    {
        Debug.Log("amount = "+ amount);

        canvas_HealthBar.gameObject.SetActive(true);
        _health_Enemy -= amount;  //amount kadar can� azalt
        HealtBar.fillAmount = _health_Enemy / _totalHealth_Enemy;

        if (_health_Enemy <= 0)
        {
            animationController.StartDying();
            Debug.Log("d��man �ld�");
           
            
            stone.transform.parent.GetComponent<warControl>()._shoot = false;
            stone.transform.parent.GetComponent<warControl>()._nearestDistance = 10000;
            
            lvlControl.listOfallEnemy.Remove(this.gameObject);   //listeden de siliyor sahneden silince
            //Destroy(this.gameObject);

            //this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stone" && this.gameObject!=null)
        {
            //hasar miktar�n� warrior chicken dan silah�na g�re al�r 
           
            this.amount = other.gameObject.transform.parent.GetComponentInParent<warControl>()._warriorChickenSO.amountofDamage;

            other.gameObject.SetActive(false);
            reduceHealth(amount,other.gameObject);
           
            Debug.Log("�arpt�");
        }
        if (other.gameObject.tag == "Bullet" && this.gameObject != null)
        {
            if (other.transform.parent.TryGetComponent(out PlayerMovement p))
            {
                return;
            }
            Debug.Log("BİLMİYORUM");
            //hasar miktar�n� warrior chicken dan silah�na g�re al�r 
            
            this.amount = other.gameObject.transform.parent.GetComponentInParent<warControl>()._warriorChickenSO.amountofDamage;

            other.gameObject.SetActive(false);
            reduceHealth(amount, other.gameObject);

            Debug.Log("�arpt�");
        }

    }

    public void GoWait()
    {
        _counterattack = false;
        animationController.StartIdle();
        gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 0 ;
        nMesh.destination = startingPosition;

        transform.DORotate(startingRotation, 1f);
    }

    public void counterAttack()
    {
        
        //d��man b�lgesine girentavuk olup olmad���n� kontrol eder.
        if(_counterattack)
        {
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = 2;
            _AllWarriorChicken = lvlControl.listOfallWarriorChicken;


            //Hi� sava�acak tavuk yoksa sava�� durdur.
            if(_AllWarriorChicken.Count == 0)
            {
                GoWait();
            }

            for (int i = 0; i < _AllWarriorChicken.Count; i++)
            {
                
                _distance = Vector3.Distance(this.transform.position, _AllWarriorChicken[i].transform.position);

                if (_distance < _nearestDistance)
                {
                    NearestOBJ = _AllWarriorChicken[i];
                    _nearestDistance = _distance;
                }
                    

            }
            if(NearestOBJ == null)
            {
                _nearestDistance = 10000;
            }
            else
            {
                _tempPosition = NearestOBJ.transform;
                
            }


            if (flag)
            {
                createGun();
                flag = false;
            }
        }
        else
        {
            GoWait();
        }
        
    }

   
    
    public void createGun()
    {
        if (!_counterattack)
        {
            return;
        }
        
        if (_activeGun == null && NearestOBJ != null)
        {
            string nameOfActiveGun = enemySO.gun.gameObject.tag;
            
            if(nameOfActiveGun == "EnemyStone")
            {

                
                animationController.StartFire(true);
                _activeGun = Instantiate(enemySO.gun, stonePlace.transform.position, stonePlace.transform.rotation, transform);

                if (NearestOBJ != null && _tempPosition != null)
                {

                    //y�n�n� ona �evirsin


                    var newRotation = Quaternion.LookRotation(transform.position - _tempPosition.position);
                    //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .5f);
                    transform.DORotateQuaternion(newRotation, .5f);
                    Debug.DrawRay(transform.position, _tempPosition.position - transform.position, Color.blue);

                    nMesh.destination = _tempPosition.position;



                    _activeGun.transform.DOJump(_tempPosition.position, _jumpPower, _jumpCount, _duration);
                    Destroy(_activeGun, _duration + 0.1f);
                }



            }else if(nameOfActiveGun == "BulletEnemy" )
            {
                
                //Debug.Log("LEVEL 2 ATEŞ EDİYOR");
                animationController.StartFire(false);
                _activeGun = Instantiate(enemySO.gun, gunPlace.transform.position, gunPlace.transform.rotation, transform);
               

                if (NearestOBJ != null && _tempPosition != null)
                {

                    //y�n�n� ona �evirsin


                    var newRotation = Quaternion.LookRotation(transform.position - _tempPosition.position);
                    //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .5f);
                    transform.DORotateQuaternion(newRotation, .5f);
                    Debug.DrawRay(transform.position, _tempPosition.position - transform.position, Color.blue);

                    nMesh.destination = _tempPosition.position;

                    gun.transform.DORotateQuaternion(newRotation, .1f);
                    var newPos = new Vector3(_tempPosition.position.x, _tempPosition.position.y + 0.5f,
                        _tempPosition.position.z);
                    _activeGun.transform.DOMove(newPos, _duration);
                    Destroy(_activeGun, _duration + 0.1f);
                }


            }
            

        }

    }

  

}
