using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMenegment : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject settings;
    public GameObject MusicOn;
    public GameObject MusicOff;

    public void SettingsBtn()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void BackToMenuBtn()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void MusicOnBtn()
    {
        MusicOff.SetActive(true);
        MusicOn.SetActive(false);
    }

    public void MusicOffBtn()
    {
        MusicOff.SetActive(false);
        MusicOn.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}