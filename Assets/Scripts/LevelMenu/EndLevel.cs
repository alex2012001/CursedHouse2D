using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public LevelController lvl;
    public TimerForEnemySpawn timer;
    public EnemySpawner spawner;
    public GameObject WinScreen1;
    public GameObject WinScreen2;


    private void Update()
    {
        if (timer.AllWaves&& spawner.allDie)
        {
            StartCoroutine(NextLvl());
        }
    }

    IEnumerator NextLvl()
    {
        WinScreen1.SetActive(true);
        yield return new WaitForSeconds(5);
        WinScreen2.SetActive(true);
        if (Input.anyKeyDown)
        {
            lvl.isEndGame();
        }
        yield return null;
    }



}
