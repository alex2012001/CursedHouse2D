using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BladeTrap : MonoBehaviour
{
    private BladeSpawnTrap spawn;
    private EnemyHealthPoints enemyHp;

    public float damage;

    private bool move=false;
    private float speed=8;

    private void Start()
    {
        spawn = transform.parent.GetComponent<BladeSpawnTrap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false||collision.gameObject.tag=="FlyingEnemy"&&collision.isTrigger==false)
        {
            enemyHp = collision.gameObject.GetComponent<EnemyHealthPoints>();
            StartCoroutine(TakeDamage());
            move = true;
        }
    }
   

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawn.moveingTo.position, Time.deltaTime * speed);
            if (transform.position.y == spawn.moveingTo.position.y)
            {
                spawn.isReload = false;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(0.2f);
        enemyHp.hp -= damage;
        enemyHp = null;
        yield return null;
    }

}
