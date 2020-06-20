using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerForEnemySpawn : MonoBehaviour
{
    [Header("Индикатор")]
    public Text myText;

    public EnemySpawner enemyspawn;

    [Header("Осталось времени")]
    public int timeLeftForDay = 60;
    public int timeLeftForNight = 180;
    private int timeLeft;
    private float gameTime;
    private bool day = true;
    private bool newWaves = false;
    private void Start()
    {
        timeLeft = timeLeftForDay;
        myText.color = Color.white;
       // StartCoroutine(EnemySpawn());
    }
    void Update()
    {
        if (day)
        {
            myText.text = "До наступления ночи осталось " + timeLeft + " сек";
            gameTime += 1 * Time.deltaTime;
            if (gameTime >= 1)
            {
                timeLeft -= 1;
                gameTime = 0;
            }
            if (timeLeft < 20)
            {
                myText.color = Color.red;
            }
            if (timeLeft == 0)
            {
                day = false;
                myText.color = Color.red;
                timeLeft = timeLeftForNight;
                newWaves = true;
            }
        }
        else
        {
            if (newWaves)
            {
                StartCoroutine(EnemySpawn());
                newWaves = false;
            }
            myText.text = "До наступления дня осталось " + timeLeft + " сек";
            gameTime += 1 * Time.deltaTime;
            if (gameTime >= 1)
            {
                timeLeft -= 1;
                gameTime = 0;
            }

            if (timeLeft == 0)
            {
                day = true;
                timeLeft = timeLeftForDay;
                myText.color = Color.white;
            }
        }
    }

        IEnumerator EnemySpawn()
    {
        enemyspawn.newWaveSpawn = true;
        yield return new WaitForSeconds(60);
        enemyspawn.newWaveSpawn = true;
        yield return new WaitForSeconds(60);
        enemyspawn.newWaveSpawn = true;
        yield return null;
    }
}
