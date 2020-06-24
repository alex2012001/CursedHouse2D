using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Falling : MonoBehaviour
{
    public AudioSource stunSound;

    public GameObject rightStunText;

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
            //if (collision.gameObject.tag.Equals("Ground"))
            //{
            //    Debug.Log(pl.rb.velocity.y);
            //}

            if (collision.gameObject.tag.Equals("Ground") && pl.rb.velocity.y < -5)
            {
                stunSound.Play();
                StartCoroutine(Stun());
            }
            if (collision.gameObject.tag.Equals("Ground") && pl.rb.velocity.y < -7.5)
            {
                pl.damageSound.Play();
                pl.healthFill -= 0.25f;
            }
            if (collision.gameObject.tag.Equals("Ground") && pl.rb.velocity.y < -10)
            {
                pl.healthFill -= 0.25f;
            }
        }
    }
  
    IEnumerator Stun()
    {
        rightStunText.SetActive(true);
        pl.canMove = false;
        yield return new WaitForSeconds(1.5f);
        pl.canMove = true;
        rightStunText.SetActive(false);
        yield return null;
    }

}
