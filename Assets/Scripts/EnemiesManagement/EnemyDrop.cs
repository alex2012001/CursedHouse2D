using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{

    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"&&collision.isTrigger==false)
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 50;          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"&& collision.isTrigger == false)
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
        }
    }



}
