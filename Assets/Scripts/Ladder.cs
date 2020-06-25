using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]

    float speed = 5;
    private Collider2D collision2D;
    private bool inLadder = false;
    private PlayerMove plMove;

    public AudioSource ladderSound;

    private void Start()
    {
        plMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        collision2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (inLadder)
        {
            if (plMove.playerOnLadder == 1)
            {
                ladderSound.mute = false;
                    collision2D.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else if (plMove.playerOnLadder ==-1)
            {
                ladderSound.mute = false;
                collision2D.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else if(plMove.playerOnLadder==0)
            {
                ladderSound.mute = true;
                collision2D.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            inLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ladderSound.mute = true;
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
            inLadder = false;
        }
    }
}
