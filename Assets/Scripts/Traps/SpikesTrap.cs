using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrap : MonoBehaviour
{
    public float damage;
    private EnemyHealthPoints enemyHp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            enemyHp = collision.GetComponent<EnemyHealthPoints>();
            enemyHp.hp -= damage;
           // StartCoroutine(SpikeDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyHp = null;
    }

    //IEnumerator SpikeDamage()
    //{
    //    yield return new WaitForSeconds(1);
    //    if (enemyHp != null)
    //    {
    //        enemyHp.hp -= damage;
    //    }
    //    yield return null;
    //}

}
