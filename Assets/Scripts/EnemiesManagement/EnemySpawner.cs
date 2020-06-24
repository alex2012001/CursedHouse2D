using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject FlyingEnemyLinear;
    public GameObject FlyingEnemyLoop;
    public GameObject WalkingEnemy;

    public Transform[] SpawnpointsForFlying;
    public Transform[] SpawnpointsForWalking;

    int[] waves = new int[3];
    private int waveNumber = 1;
    public bool newWaveSpawn=false;

    public int enemyCount;
    public bool allDie;

    private void Awake()
    {
        waves[0] = 2;
        waves[1] = 3;
        waves[2] = 4;
        enemyCount = 0;
    }
    private void Start()
    {
        allDie = false;
    }

    void Update()
    {
        if (waveNumber < 4 && newWaveSpawn)
        {
            EnemySpawn();
        }
        if (waveNumber == 4 && enemyCount == 0)
        {
            StartCoroutine(Wait());
        }



    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        if (enemyCount == 0)
        {
            allDie = true;
        }
        yield return null;
    }

    private void EnemySpawn()
    {
        int [] exceptionArray = new int[6];
        int fly = Random.Range(1, waves[waveNumber-1]);
        int walk = waves[waveNumber-1] - fly;
        while (fly > 0)
        {
            int r = Random.Range(1, 7);
            if (exceptionArray[r-1]!=1) 
            {
                exceptionArray[r - 1] = 1;
                switch (r)
                {
                    case 1: Instantiate(FlyingEnemyLoop, SpawnpointsForFlying[0]); break;
                    case 2: Instantiate(FlyingEnemyLoop, SpawnpointsForFlying[1]); break;
                    case 3: Instantiate(FlyingEnemyLinear, SpawnpointsForFlying[2]); break;
                    case 4: Instantiate(FlyingEnemyLinear, SpawnpointsForFlying[3]); break;
                    case 5: Instantiate(FlyingEnemyLinear, SpawnpointsForFlying[4]); break;
                    case 6: Instantiate(FlyingEnemyLinear, SpawnpointsForFlying[5]); break;
                }
                fly--;
            }
        }
        while (walk > 0)
        {
            int r = Random.Range(1, 7);
            if (exceptionArray[r - 1]!=1)
            {
                exceptionArray[r - 1] = 1;
                switch (Random.Range(1, 7))
                {
                    case 1: Instantiate(WalkingEnemy, SpawnpointsForWalking[0]); break;
                    case 2: Instantiate(WalkingEnemy, SpawnpointsForWalking[1]); break;
                    case 3: Instantiate(WalkingEnemy, SpawnpointsForWalking[2]); break;
                    case 4: Instantiate(WalkingEnemy, SpawnpointsForWalking[3]); break;
                    case 5: Instantiate(WalkingEnemy, SpawnpointsForWalking[4]); break;
                    case 6: Instantiate(WalkingEnemy, SpawnpointsForWalking[5]); break;
                }
                walk--;
            }
        }
        newWaveSpawn = false;
        waveNumber++;
    }
}
