using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterChoice : MonoBehaviour
{
    public string loadLevel;
    public GameObject loadingScreen;
    public Slider loadBar;

    public GameObject Player2; 
    public GameObject Player1; 
    public GameObject Player3;

    public GameObject textPlayer1;
    public GameObject textPlayer2;
    public GameObject textPlayer3;

    private Vector3 charPosition;
    private Vector3 charOutside;

    private int charInt = 1;

    private SpriteRenderer Player1Ren, Player2Ren, Player3Ren;

    private readonly string charSelected = "charSelected";

    private void Awake()
    {
        charPosition = Player1.transform.position;
        charOutside = Player2.transform.position;

        Player2Ren = Player2.GetComponent<SpriteRenderer>();
        Player3Ren = Player3.GetComponent<SpriteRenderer>();
        Player1Ren = Player1.GetComponent<SpriteRenderer>();

        PlayerPrefs.SetInt(charSelected, 3);
    }

    private void Start()
    {

    }

    public void Next()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 1);
                Player1Ren.enabled = false;
                Player1.transform.position = charOutside;
                Player2.transform.position = charPosition;
                Player2Ren.enabled = true;
                charInt = 2;
                textPlayer1.SetActive(false);
                textPlayer2.SetActive(true);
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 2);
                Player2Ren.enabled = false;
                Player2.transform.position = charOutside;
                Player3.transform.position = charPosition;
                Player3Ren.enabled = true;
                charInt = 3;
                textPlayer2.SetActive(false);
                textPlayer3.SetActive(true);
                break;
            case 3:
                PlayerPrefs.SetInt(charSelected, 3);
                Player3Ren.enabled = false;
                Player3.transform.position = charOutside;
                Player1.transform.position = charPosition;
                Player1Ren.enabled = true;
                charInt = 1;
                textPlayer3.SetActive(false);
                textPlayer1.SetActive(true);
                break;
        }

    }

    public void Previous()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 2);
                Player1Ren.enabled = false;
                Player1.transform.position = charOutside;
                Player3.transform.position = charPosition;
                Player3Ren.enabled = true;
                charInt = 3;
                textPlayer1.SetActive(false);
                textPlayer3.SetActive(true);
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 3);
                Player2Ren.enabled = false;
                Player2.transform.position = charOutside;
                Player1.transform.position = charPosition;
                Player1Ren.enabled = true;
                charInt = 1;
                textPlayer2.SetActive(false);
                textPlayer1.SetActive(true);
                break;
            case 3:
                PlayerPrefs.SetInt(charSelected, 1);
                Player3Ren.enabled = false;
                Player3.transform.position = charOutside;
                Player2.transform.position = charPosition;
                Player2Ren.enabled = true;
                charInt = 2;
                textPlayer3.SetActive(false);
                textPlayer2.SetActive(true);
                break;
        }
    }
    public void Managerr()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(loadLevel);

        asynkLoad.allowSceneActivation = false;

        while (!asynkLoad.isDone)
        {
            loadBar.value = asynkLoad.progress;
            if (asynkLoad.progress >= .9f && !asynkLoad.allowSceneActivation)
            {
               // if (Input.anyKeyDown)
               //{
                    asynkLoad.allowSceneActivation = true; // Запустит следующую сцену при нажатии на экран
               // }
            }
            yield return null;
        }
    }
}
