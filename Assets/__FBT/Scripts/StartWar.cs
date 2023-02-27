using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartWar : MonoBehaviour
{
    Color objectColor;

    GameObject objectFilled;

     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "StartWar")
         {

            objectColor = other.gameObject.transform.Find("BattleFilled").GetComponent<SpriteRenderer>().color;

            objectFilled = other.gameObject.transform.Find("BattleFilled").gameObject;


            StopCoroutine(FadeOut());

            StartCoroutine("FadeIn");


            /*
            foreach (var chicken in lvlControl.listOfallWarriorChicken)
            {
                chicken.GetComponent<warControl>().stateOfWar();
            }
            */

        }
     }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StartWar")
        {

            objectColor = other.gameObject.transform.Find("BattleFilled").GetComponent<SpriteRenderer>().color;
        
            objectFilled = other.gameObject.transform.Find("BattleFilled").gameObject;


            StopCoroutine("FadeIn");

            StartCoroutine(FadeOut());


        }
    }


    IEnumerator FadeIn()
    {
        for (float f =objectFilled.GetComponent<SpriteRenderer>().color.a; f <= 1; f += 0.05f)
        {

            objectFilled.GetComponent<SpriteRenderer>().color = new Color(objectColor.r,objectColor.g,objectColor.b,f);

            yield return new WaitForSeconds(0.05f);
        }

        foreach (var chicken in lvlControl.listOfallWarriorChicken)
        {
            chicken.GetComponent<warControl>().stateOfWar();
        }
    }

    IEnumerator FadeOut()
    {
        for (float f = objectFilled.GetComponent<SpriteRenderer>().color.a; f >=0; f -= 0.05f)
        {

            objectFilled.GetComponent<SpriteRenderer>().color = new Color(objectColor.r, objectColor.g, objectColor.b, f);

            yield return new WaitForSeconds(0.05f);
        }
    }

   

    
}
