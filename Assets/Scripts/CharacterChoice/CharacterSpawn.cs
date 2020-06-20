using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public Transform spawnTransform;
    private readonly string charSelected = "charSelected";

    private void Awake()
    {
        int getChar;

        getChar = PlayerPrefs.GetInt("charSelected");

        switch (getChar)
        {
            case 1:
                Instantiate(Player2, spawnTransform.transform);
                break;
            case 2:
                Instantiate(Player3, spawnTransform.transform);
                break;
            case 3:
                Instantiate(Player1, spawnTransform.transform);
                break;
        }
    }
}
