using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Button Lvl2;
    public Button Lvl3;
    int levelComplete;

    public GameObject loadingScreen;
    public Slider loadBar;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Lvl2.interactable = false;
        Lvl3.interactable = false;

        switch(levelComplete)
        {
            case 1:
                Lvl2.interactable = true;
                break;
            case 2:
                Lvl2.interactable = true;
                Lvl3.interactable = true;
                break;
        }
    }

    //public void LoadTo(int level)
    //{
    //    SceneManager.LoadScene(level);
    //}

        public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Managerr(int level)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(level));
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
