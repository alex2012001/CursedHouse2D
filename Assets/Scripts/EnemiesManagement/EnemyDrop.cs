using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyDrop : MonoBehaviour
{
    private AIPath path;
    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"&&collision.isTrigger==false)
        {
            path = collision.gameObject.GetComponent<AIPath>();
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
            StartCoroutine(Stun());
        }
    }

    IEnumerator Stun()
    {
        path.canMove = false;
        yield return new WaitForSeconds(2f);
        path.canMove = true;
        path = null;
        yield return null;
    }

}
