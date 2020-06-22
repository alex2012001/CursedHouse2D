using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject Player1;

    public Transform spawnTransform;

    private void Awake()
    {
        
         Instantiate(Player1, spawnTransform.transform);
    }
}
