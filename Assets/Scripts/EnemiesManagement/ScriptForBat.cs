using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForBat : MonoBehaviour
{
    public int hp = 3;
    void Update()
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;
        }
    }
}
