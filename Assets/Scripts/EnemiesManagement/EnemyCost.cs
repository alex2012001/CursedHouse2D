using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCost : MonoBehaviour
{
    public GameObject crystal;
    public int crystalCount;

    public void CrystalSpawn()
    {
        float x = 0;
        while (crystalCount > 0)
        {
            Instantiate(crystal,new Vector3(transform.position.x+x,transform.position.y,transform.position.z),Quaternion.identity);
            x += 0.25f;
            crystalCount--;
        }
    }
}
