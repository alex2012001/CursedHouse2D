﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public static bool GameIsPaused = false;
    public void Resume()
    { 
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseButton.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
        yield return null;
    }
}
