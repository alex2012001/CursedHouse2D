using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalsCounter : MonoBehaviour
{
    private PlayerCrystals playerCrystals;
    public Text text;
    void Start()
    {
        text.color = Color.white;
        playerCrystals = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCrystals>();        
    }

    void Update()
    {
        text.text = "X "+ playerCrystals.count;

        if(playerCrystals.count == 3)
        {

        }
    }
}
