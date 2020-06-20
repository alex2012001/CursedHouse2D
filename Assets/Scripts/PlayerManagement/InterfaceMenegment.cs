using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InterfaceMenegment : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{
    private Attack playerAttack;
  //  private Shooting playerShoot;
    private PlayerMove playerMove;
    private PlayerCrystals playerCrystals;
    private void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
       //playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        playerCrystals = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCrystals>();
    }

    //public void BuyPressed()
    //{
    //    playerCrystals.Buy();
    //}
    public void MeleeAttacki()
    {
        playerAttack.AttackButtonDown();
    }
    //public void RangeAttack()
    //{
    //    playerShoot.Shoot();
    //}

    public void PlayerJump()
    {
        playerMove.Jump();
    }

    public void PointerDown()
    {
        playerCrystals.checkOnBuy = true;
        Debug.Log("Нажал");
    }

    public void PointerUp()
    {
        Debug.Log("Отпустил");
        playerCrystals.checkOnBuy = false;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    playerCrystals.checkOnBuy = true;
    //    Debug.Log("Нажал");
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Debug.Log("Отпустил");
    //    playerCrystals.checkOnBuy = false;
    //}
}
