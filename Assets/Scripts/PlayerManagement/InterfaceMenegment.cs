using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InterfaceMenegment : MonoBehaviour
{
    private Attack playerAttack;
    private PlayerMove playerMove;
    private PlayerCrystals playerCrystals;
    private void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        playerCrystals = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCrystals>();
    }


    public void MeleeAttacki()
    {
        playerAttack.AttackButtonDown();
    }

    public void PlayerJump()
    {
        playerMove.Jump();
    }

    public void PointerDown()
    {
        playerCrystals.checkOnBuy = true;
    }

    public void PointerUp()
    {
        playerCrystals.checkOnBuy = false;
    }
}
