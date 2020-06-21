using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    public float damage;
    private EnemyHealthPoints enemyHp;

    void Update()
    {
        gameObject.transform.Rotate(0, 0, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false || collision.gameObject.tag == "FlyingEnemy" && collision.isTrigger == false)
        {
            enemyHp = collision.GetComponent<EnemyHealthPoints>();
            enemyHp.hp -= damage;
        }
    }
}
