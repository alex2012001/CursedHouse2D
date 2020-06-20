using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
   
    public static LevelController insctance = null;
        int sceneIndex;
    int levelComplete;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

   
    public void isEndGame()
    {
        if(sceneIndex == 5)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if(levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                Invoke("EndLevel", 1f);
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
