using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }

    private AIPath path;

    private bool facingRight = true;

    public bool Persecution = false;

    public MovementType Type = MovementType.Moveing;
    public MovementPath MyPath;
    public float speed = 1;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;
    void Start()
    {

       
        path = GetComponent<AIPath>();
        if (MyPath == null)
        {
            Debug.Log("Примени путь");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("Нужны точки");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }
        if (!Persecution)
        {
            if (Type == MovementType.Moveing)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
                if (facingRight && transform.position.x > pointInPath.Current.position.x)
                {
                    Flip();
                }
                if (!facingRight && transform.position.x < pointInPath.Current.position.x)
                {
                    Flip();
                }

            }
            else if (Type == MovementType.Lerping)
            {
                transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
            }

            var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSqure < maxDistance * maxDistance)
            {
                pointInPath.MoveNext();
            }
        }
        if (Persecution)
        {
            if (path.desiredVelocity.x >= 0.01f && !facingRight)
            {
                Flip();
            }
            else if (path.desiredVelocity.x <= -0.01f && facingRight)
            {
                Flip();
            }

        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Persecution = true;
            path.canMove = true;
        }
    }
}
