using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
   
    public static LevelController insctance = null;
      public  int sceneIndex;
   public int levelComplete;

    void Start()
    {
        if(insctance == null)
        {
            insctance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

   
    public void isEndGame()
    {
      

        //if (sceneIndex == 5)
        //{
        //    Invoke("LoadMainMenu", 1f);
        //}
        //else
        //{
            if(levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                NextLevel();
            }
        //}
    }

   void NextLevel()
    {
        //StartCoroutine(LoadAsync());
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //IEnumerator LoadAsync(int level)
    //{
    //    AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(sceneIndex + 1);

    //    asynkLoad.allowSceneActivation = false;

    //    while (!asynkLoad.isDone)
    //    {
    //        loadBar.value = asynkLoad.progress;
    //        if (asynkLoad.progress >= .9f && !asynkLoad.allowSceneActivation)
    //        {
    //            asynkLoad.allowSceneActivation = true;
    //        }
    //        yield return null;
    //    }
    //}
}
