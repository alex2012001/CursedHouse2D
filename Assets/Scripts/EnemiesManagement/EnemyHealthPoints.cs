using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthPoints : MonoBehaviour
{
    public float hp;

    public Image healthBar;

    private EnemyCost enemyCost;
    private AIPath path;

    private void Start()
    {
        enemyCost = GetComponent<EnemyCost>();
        path = GetComponent<AIPath>();
    }
    void Update()
    {
        healthBar.fillAmount = hp;
        if (hp <= 0.01)
        {
            enemyCost.CrystalSpawn();
            Destroy(gameObject);
        }


    }

    public void TakeDamage(float damage)
    {
        if (path.canMove)
        {
            float buf = hp;
            hp -= damage;
            if (hp <= 0)
            {
                hp = buf;
            }
            StartCoroutine(StunTime());
        }
    }

    IEnumerator StunTime()
    {
        path.canMove = false;
        yield return new WaitForSeconds(2);
        path.canMove = true;
        yield return null;
    }


}
