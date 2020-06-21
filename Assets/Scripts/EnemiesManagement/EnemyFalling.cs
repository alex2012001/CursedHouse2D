//using Pathfinding;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyFalling : MonoBehaviour
//{
//    private EnemyHealthPoints enemyHp;
//    private Rigidbody2D rb;
//    private AIPath path;
//    void Start()
//    {
//        rb = transform.parent.GetComponent<Rigidbody2D>();
//        enemyHp = transform.parent.GetComponent<EnemyHealthPoints>();
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag.Equals("Ground"))
//        {
//            Debug.Log(rb.velocity.y);
//        }
//        if (collision.gameObject.tag.Equals("Ground")&& rb.velocity.y < -5)
//        {
//            StartCoroutine(Stun());
//        }
//    }

//    IEnumerator Stun()
//    {
//        path.canMove = false;
//        yield return new WaitForSeconds(1.5f);
//        path.canMove = true;
//        yield return null;
//    }
//}
