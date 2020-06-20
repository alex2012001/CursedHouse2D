using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falling : MonoBehaviour
{
    public static bool fallCheck = true;
    private PlayerMove pl;
    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fallCheck)
        {
            if (collision.gameObject.tag.Equals("Ground"))
            {
                Debug.Log(pl.rb.velocity.y);
            }

            if (collision.gameObject.tag.Equals("Ground") && pl.rb.velocity.y < -6)
            {
                pl.healthFill -= 0.25f;
                Debug.Log("Damage");
            }
        }
    }


}
