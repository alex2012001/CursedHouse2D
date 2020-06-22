using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Collider2D platform;
    private Joystick joystick;  
    void Start()
    {
        platform = GetComponent<Collider2D>();
        joystick = GameObject.FindGameObjectWithTag("joystick").GetComponent<Joystick>();
    }


    void Update()
    {
        if (joystick.Vertical() < -0.3)
        {
            platform.isTrigger = true;
        }
        else
        {
            platform.isTrigger = false;
        }
    }
}
