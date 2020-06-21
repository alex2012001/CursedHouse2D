using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeSpawnTrap : MonoBehaviour
{
    public GameObject blade;
    public bool isReload = true;
    public Transform moveingTo;
    public Image reloadProgress;

    private PlayerCrystals playerCrystals;
    private float gameTime;
    private int reloadTime = 3;
    private int clickForReloadTime=0;
    private void Start()
    {
        Instantiate(blade,transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCrystals = collision.gameObject.GetComponent<PlayerCrystals>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCrystals = null;
        }
    }

    private void Update()
    {
        if (playerCrystals!=null)
        {
            if(playerCrystals.checkOnBuy&&!isReload)
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
        isReload = true;
        Instantiate(blade, transform);
        clickForReloadTime = 0;
        reloadProgress.fillAmount = 0f;
    }
}
