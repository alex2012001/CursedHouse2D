using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerForEnemySpawn : MonoBehaviour
{
    [Header("Индикатор")]
    public Text myText;

    public EnemySpawner enemyspawn;

    private int waveNumber = 1;
    public bool AllWaves;

    [Header("Осталось времени")]
    public int timeLeftForNight = 60;
    private int timeLeft;
    private float gameTime;
    private bool day = true;
    private bool newWaves = false;

   
    private void Start()
    {
        AllWaves = false;
        timeLeft = timeLeftForNight;
        myText.color = Color.white;
       
    }

    private void Awake()
    {
        
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
            myText.text = "До следующей волны " + timeLeft + " сек";
            gameTime += 1 * Time.deltaTime;
            if (gameTime >= 1)
            {
                timeLeft -= 1;
                gameTime = 0;
            }

            if (timeLeft == 0&&waveNumber<3)
            {
                timeLeft = 60;
                waveNumber++;
            }
            else if(waveNumber>=3)
            {
                myText.text = "Убейте всех монстров чтобы выйграть";
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
        AllWaves = true;
        yield return null;
    }
}
