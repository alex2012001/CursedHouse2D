using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float bulletSpeedX=4f;
    public Rigidbody2D rbBullet;
    private int timeLeft = 1;
    private float gameTime;
    void Start()
    {
        rbBullet.velocity = transform.right * bulletSpeedX;
    }
    private void Update()
    {
        gameTime += 1 * Time.deltaTime;
        if (gameTime >= 1)
        {
            timeLeft -= 1;
            gameTime = 0;
        }
        if (timeLeft == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
