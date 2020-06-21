using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikesTrap : MonoBehaviour
{
    private PlayerCrystals playerCrystals;
    public float damage;
    private EnemyHealthPoints enemyHp;
    private bool isActive=true;

    private int reloadTime = 3;
    private int clickForReloadTime=0;
    private float gameTime;
    public Image reloadProgress;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false&&isActive)
        {
            enemyHp = collision.GetComponent<EnemyHealthPoints>();
            StartCoroutine(SpikeDamage());
            isActive = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            playerCrystals = collision.GetComponent<PlayerCrystals>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false)
        {
            enemyHp = null;
        }
        if(collision.gameObject.tag == "Player")
        {
            playerCrystals = null;
        }
    }

    private void Update()
    {
        if (playerCrystals != null)
        {
            if (!isActive && playerCrystals.checkOnBuy)
            {
                reloadProgress.fillAmount = clickForReloadTime * 0.33f;
                gameTime += 1 * Time.deltaTime;
                if (gameTime >= 1)
                {
                    clickForReloadTime += 1;
                    gameTime = 0;
                }
                if (clickForReloadTime == reloadTime)
                {
                    Reload();
                }
            }
            if (!playerCrystals.checkOnBuy)
            {
                reloadProgress.fillAmount = 0f;
            }
        }
    }

    private void Reload()
    {
        isActive = true;
        reloadProgress.fillAmount = 0f;
        clickForReloadTime = 0;
    }

    IEnumerator SpikeDamage()
    {
        anim.SetBool("takeDamage", true);
        yield return new WaitForSeconds(0.5f);
        if (enemyHp != null)
        {
            enemyHp.hp -= damage;
        }
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("takeDamage", false);
        yield return null;
    }

}
