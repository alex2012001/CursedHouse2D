using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    private bool facingLeft = false;

   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (aiPath.desiredVelocity.x >= 0.01f&& facingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            facingLeft = !facingLeft;
            //transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f&&!facingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            facingLeft = !facingLeft;
            //transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
