using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Button Lvl2;
    public Button Lvl3;
    public Button Lvl4;
    public Button Lvl5;
    public Button Lvl6;
    public Button Lvl7;
    public Button Lvl8;
    public Button Lvl9;
    public Button Lvl10;
    public Button Lvl11;
    public Button Lvl12;
    public Button Lvl13;
    public Button Lvl14;
    public Button Lvl15;
   
    int levelComplete;

    public GameObject loadingScreen;
    public Slider loadBar;

    public GameObject text;
    public GameObject button;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Lvl2.interactable = false;
        Lvl3.interactable = false;
        Lvl4.interactable = false;
        Lvl5.interactable = false;
        Lvl6.interactable = false;
        Lvl7.interactable = false;
        Lvl8.interactable = false;
        Lvl9.interactable = false;
        Lvl10.interactable = false;
        Lvl11.interactable = false;
        Lvl12.interactable = false;
        Lvl13.interactable = false;
        Lvl14.interactable = false;
        Lvl15.interactable = false;

        switch (levelComplete)
        {
            case 1:
                Lvl2.interactable = true;
               // Lvl3.interactable = true;
                break;
        }
    }
        public void BackToMenu()
    {
        StartCoroutine(time());
    }

    public void Managerr(int level)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(level));
        text.SetActive(false);
        button.SetActive(false);
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
        yield return null;

    }

    IEnumerator LoadAsync(int level)
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(level);

        asynkLoad.allowSceneActivation = false;

        while (!asynkLoad.isDone)
        {
            loadBar.value = asynkLoad.progress;
            if (asynkLoad.progress >= .9f && !asynkLoad.allowSceneActivation)
            {
                asynkLoad.allowSceneActivation = true; 
            }
            yield return null;
        }
    }

}
