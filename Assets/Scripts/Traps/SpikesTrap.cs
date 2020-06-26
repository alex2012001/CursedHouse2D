using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

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

    public AudioSource spikeSound;

    public GameObject needToReload;

    private Animator anim;

    public AudioSource buildSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false&&isActive || collision.gameObject.tag == "FlyingEnemy" && collision.isTrigger == false&&isActive)
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
        if (collision.gameObject.tag == "Enemy" && collision.isTrigger == false || collision.gameObject.tag == "FlyingEnemy" && collision.isTrigger == false)
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
                buildSound.mute = false;
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
            else
            {
                buildSound.mute = true;
                clickForReloadTime = 0;
                reloadProgress.fillAmount = 0f;
            }
        }
    }

    private void Reload()
    {
        StartCoroutine(Anim());
        needToReload.SetActive(false);
        isActive = true;
        reloadProgress.fillAmount = 0f;
        clickForReloadTime = 0;
    }

    IEnumerator Anim()
    {
        anim.SetInteger("trap", 3);
        yield return new WaitForSecondsRealtime(0.5f);
        anim.SetInteger("trap", 4);
        yield return null;
    }

    IEnumerator SpikeDamage()
    {
        anim.SetInteger("trap", 1);
        yield return new WaitForSeconds(0.2f);
        spikeSound.Play();
        yield return new WaitForSeconds(0.3f);
        if (enemyHp != null)
        {
            enemyHp.hp -= damage;
        }
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("trap", 2);
        needToReload.SetActive(true);
        yield return null;
    }
}
