using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Joystick : MonoBehaviour, IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    Image joystickBg;
    Image joystick;
    Vector2 inputVector;

    PlayerMove plMove;
    private bool facingRight = true;

  

    void Start()
    {
        plMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        joystickBg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
       

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / joystickBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBg.rectTransform.sizeDelta.y);
        }
        inputVector = new Vector2(pos.x, pos.y);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBg.rectTransform.sizeDelta.x / 2), (inputVector.y) * (joystickBg.rectTransform.sizeDelta.y / 2));
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition=Vector2.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            if (inputVector.x < 0 && facingRight)
                Flip();
            if (inputVector.x > 0 && !facingRight)
                Flip();
            return Math.Abs(inputVector.x / 15);

            
        }
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y !=0.4 )
        {
            return inputVector.y;
        }
        else
            return Input.GetAxis("Vertical");
    }
    public void Flip()
    {
        facingRight = !facingRight;
        plMove.transform.Rotate(0f, 180f, 0f);
    }
}
