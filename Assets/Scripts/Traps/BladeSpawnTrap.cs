using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class BladeSpawnTrap : MonoBehaviour
{
    public AudioSource bladeSound;
    public AudioSource buildSound;
   // public AudioSource 

    public GameObject blade;
    public bool isReload = true;
    public Transform moveingTo;
    public Image reloadProgress;

    private PlayerCrystals playerCrystals;
    private float gameTime;
    private int reloadTime = 3;
    private int clickForReloadTime=0;

    public GameObject needToReload;
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
        if (!isReload)
        {
            needToReload.SetActive(true);
        }
    }

    private void Reload()
    {
        needToReload.SetActive(false);
        isReload = true;
        Instantiate(blade, transform);
        clickForReloadTime = 0;
        reloadProgress.fillAmount = 0f;
    }
}
