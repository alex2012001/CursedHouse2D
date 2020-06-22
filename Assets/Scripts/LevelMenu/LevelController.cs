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
        PlayerPrefs.SetInt("LevelComplete", 2); //убрать в финальном билде
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");

        Debug.Log(levelComplete);
        Debug.Log(sceneIndex);
    }

   
    public void isEndGame()
    {
      

        if (sceneIndex == 5)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if(levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                NextLevel();
            }
        }
    }

   void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
