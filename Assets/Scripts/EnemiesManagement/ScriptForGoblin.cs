﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForGoblin : MonoBehaviour
{
    private Rigidbody2D rb;
    public AIPath path;
   // private int hp = 5;
    private bool pathFinding = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        //if (hp == 0)
        //{
        //    Destroy(gameObject);
        //}
        
        if (!path.canMove)
        {
            rb.gravityScale = 0;
        }
        else if(path.canMove&& !pathFinding)
        {
            rb.gravityScale = 1;
            pathFinding = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Arrow")
        //{
        //    hp--;
        //}
    }
    

}
