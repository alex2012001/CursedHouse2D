using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCrystals : MonoBehaviour
{
    public int count;

    private BuySpace buySpace;
    private bool buy = false;
    public bool checkOnBuy = false;
    private float gameTime;
    private int clickTime=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BuySpace")
        {
            buy = true;
            buySpace = collision.gameObject.GetComponent<BuySpace>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BuySpace")
        {
            buy = false;
            buySpace = null;
        }
    }

    private void Update()
    {
        if(buy&&checkOnBuy&&count>=buySpace.cost)
        {
            if (buySpace.progressBar != null)
            {
                buySpace.progressBar.fillAmount = clickTime * 0.25f;
            }
            gameTime += 1*Time.deltaTime;
            if (gameTime >= 1)
            {
                clickTime += 1;
                gameTime = 0;
            }
            if (clickTime == buySpace.buildTime)
            {
                buySpace.Build();
            }
        }
        if (!checkOnBuy&&buy)
        {
            clickTime = 0;
            if (buySpace.progressBar != null)
            {
                buySpace.progressBar.fillAmount = 0;
            }
        }
    }
}
