using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySpace : MonoBehaviour
{
    private PlayerCrystals playerCrystals;
    public GameObject Trap;
    public GameObject Cost;
    public GameObject Arrow;
    public int cost;
    public GameObject ghost;


    public bool isBuild;
    public int buildTime = 4;
    public Image progressBar;

    private void Start()
    {
        isBuild = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCrystals = collision.gameObject.GetComponent<PlayerCrystals>();
            if (Cost != null)
            {
                Cost.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Cost != null)
        {
            Cost.SetActive(false);
        }

    }



    public void Build()
    {
        Debug.Log("Build");
        if (playerCrystals.count >= cost&&!isBuild)
        {
            isBuild = true;
            Destroy(ghost);
            Destroy(Arrow);
            Destroy(Cost);
            Destroy(progressBar);
            playerCrystals.count -= cost;
            Trap.SetActive(true);
        }
    }
}
