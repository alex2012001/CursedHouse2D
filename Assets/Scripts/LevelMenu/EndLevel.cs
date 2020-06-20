using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    bool f = false;


    public void ifWeEndLevel()
    {
        if(f == true) //условие для переключения уровня
        {
            LevelController.insctance.isEndGame();
        }
    }

    
}
