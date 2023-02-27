using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class WromAreaInitilazior : MonoBehaviour
{
   [SerializeField] private HoleController level1, level2, level3;
   [SerializeField] private float maxX, maxZ, minZ;
   public static List<HoleController> ActiveHoles = new List<HoleController>();

   private void Start()
   {
      InitArea();
   }


   private void InitArea()
   {
      StartCoroutine(SpawnLevel1());
      StartCoroutine(SpawnLevel2());
      StartCoroutine(SpawnLevel3());
   }

   private IEnumerator SpawnLevel1()
   {
      while (true)
      {
         yield return new WaitForSeconds(level1.SpawnRate);

         var randomX = Random.Range(-maxX, maxX);
         var randomZ = Random.Range(minZ, maxZ);
         var randomPos = new Vector3(randomX, 0.01f, randomZ);
         var obj = Instantiate(level1, randomPos, Quaternion.identity, transform);
         
         ActiveHoles.Add(obj);

         StartCoroutine(KillRoutine(obj, level1.LifeTime));

      }   
      
   }
   
   
   private IEnumerator SpawnLevel2()
   {
      while (true)
      {
         yield return new WaitForSeconds(level2.SpawnRate);

         var randomX = Random.Range(-maxX, maxX);
         var randomZ = Random.Range(minZ, maxZ);
         var randomPos = new Vector3(randomX, 0.01f, randomZ);
         var obj = Instantiate(level2, randomPos, Quaternion.identity, transform);
         
         ActiveHoles.Add(obj);
         
         StartCoroutine(KillRoutine(obj, level2.LifeTime));;

      }   
      
   }
   
   private IEnumerator SpawnLevel3()
   {
      while (true)
      {
         yield return new WaitForSeconds(level3.SpawnRate);

         var randomX = Random.Range(-maxX, maxX);
         var randomZ = Random.Range(minZ, maxZ);
         var randomPos = new Vector3(randomX, 0.01f, randomZ);
         var obj = Instantiate(level3, randomPos, Quaternion.identity, transform);

         ActiveHoles.Add(obj);
         
         StartCoroutine(KillRoutine(obj, level3.LifeTime));

      }   
      
   }
   
   
   private IEnumerator KillRoutine(HoleController obj, float lifeTime)
   {
      yield return new WaitForSeconds(lifeTime);

      if (obj.isTargeted)
      {
         yield break;
      }
      
      obj.transform.DOScale(0, 0.25f).SetEase(Ease.OutBack).OnComplete(() =>
      {
         obj.isDestroyed = true;
         ActiveHoles.Remove(obj);
         Destroy(obj.gameObject);
      });
   }
      
   public IEnumerator DirectKill(HoleController obj)
   {
      yield return new WaitForSeconds(1f);

      obj.transform.DOScale(0, 0.25f).SetEase(Ease.OutBack).OnComplete(() =>
      {
         obj.isDestroyed = true;
         ActiveHoles.Remove(obj);
         Destroy(obj.gameObject);
      });
   }
}
