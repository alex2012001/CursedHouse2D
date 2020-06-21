using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private PlayerCrystals playerCrystals;

    private void Start()
    {
        playerCrystals = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCrystals>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCrystals.count++;
            Destroy(gameObject);
        }
    }
}
