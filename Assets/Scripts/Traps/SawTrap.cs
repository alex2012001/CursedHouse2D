using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SawTrap : MonoBehaviour
{
    public float damage;
    private EnemyHealthPoints enemyHp;
    public AudioSource sawSound;

    void Update()
    {
        gameObject.transform.Rotate(0, 0, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false || collision.gameObject.tag == "FlyingEnemy" && collision.isTrigger == false)
        {
            sawSound.mute = false;
            StartCoroutine(forSound());
            enemyHp = collision.GetComponent<EnemyHealthPoints>();
            enemyHp.hp -= damage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false || collision.gameObject.tag == "FlyingEnemy" && collision.isTrigger == false)
        {
            enemyHp = null;
        }
    }

    IEnumerator forSound()
    {
        yield return new WaitForSeconds(1f);
        sawSound.mute = true;
        yield return null;
    }

}
