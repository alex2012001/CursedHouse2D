using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector2 startPos;
    private Camera cum;

    private void Start()
    {
        cum = GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = cum.ScreenToWorldPoint(Input.mousePosition);
        }

        else if(Input.GetMouseButton(0))
        {
            float pos = cum.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
            float pos2 = cum.ScreenToWorldPoint(Input.mousePosition).y - startPos.y;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - pos, -1.29f, 28.79f), Mathf.Clamp(transform.position.y - pos2, -0.97f, 19.28f), transform.position.z);
        }
    }
}
