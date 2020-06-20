using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    private PlayerMove pl;

    public GameObject deadSceneText1;
    public GameObject deadSceneText2;

    public GameObject[] inter;
 
    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    void Update()
    {
        healthBar.fillAmount = pl.healthFill;
        if (pl.healthFill <= 0f)
        {
            StartCoroutine(DeadScene());
        }
    }

    IEnumerator DeadScene()
    {
        pl.speedX = 0;
        for(int i =0; i < inter.Length; i++)
        {
            inter[i].SetActive(false);
        }
        deadSceneText1.SetActive(true);
        yield return new WaitForSeconds(5);
        deadSceneText2.SetActive(true);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        yield return null;

    }
}
