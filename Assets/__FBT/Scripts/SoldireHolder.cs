using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldireHolder : MonoBehaviour
{

    public warriorChıckenSO level1, level2, level3;

    public static int currentLevel;

    public warriorChıckenSO getLevel()
    {
        if(currentLevel == 2)
        {
            return level2;
        }else if(currentLevel == 3)
        {
            return level3;
        }

        return level2;
    }
}
