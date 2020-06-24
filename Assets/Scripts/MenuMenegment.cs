using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuMenegment : MonoBehaviour
{
    public AudioSource buttoClick;

    public GameObject mainMenu;
    public GameObject settings;
    public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject SoundOn;
    public GameObject SoundOff;

    public AudioMixerGroup soundMixer;
    public AudioMixerGroup musicMixer;



    private void Start()
    {
        if (PlayerPrefs.GetInt("MusicEnabled") == 1)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        }
        else if (PlayerPrefs.GetInt("MusicEnabled") == 2)
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            musicMixer.audioMixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        }

        if (PlayerPrefs.GetInt("SoundEnabled") == 1)
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
            musicMixer.audioMixer.SetFloat("SoundVolume", 0);
        }
        else if (PlayerPrefs.GetInt("SoundEnabled") == 2)
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
            musicMixer.audioMixer.SetFloat("SoundVolume", -80);
        }
        else
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
            musicMixer.audioMixer.SetFloat("SoundVolume", 0);
        }
    }

    public void SettingsBtn()
    {
        buttoClick.Play();
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void BackToMenuBtn()
    {
        buttoClick.Play();
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void MusicOnBtn()
    {
        buttoClick.Play();
        MusicOff.SetActive(true);
        PlayerPrefs.SetInt("MusicEnabled", 2);
        musicMixer.audioMixer.SetFloat("MusicVolume", -80);
        MusicOn.SetActive(false);
    }

    public void MusicOffBtn()
    {
        buttoClick.Play();
        PlayerPrefs.SetInt("MusicEnabled", 1);
        MusicOff.SetActive(false);
        musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        MusicOn.SetActive(true);
    }


    public void SoundOnBtn()
    {
        buttoClick.Play();
        PlayerPrefs.SetInt("SoundEnabled", 2);
        SoundOff.SetActive(true);
        musicMixer.audioMixer.SetFloat("SoundVolume", -80);
        SoundOn.SetActive(false);
    }

    public void SoundOffBtn()
    {
        buttoClick.Play();
        PlayerPrefs.SetInt("SoundEnabled", 1);
        SoundOff.SetActive(false);
        musicMixer.audioMixer.SetFloat("SoundVolume", 0);
        SoundOn.SetActive(true);
    }

    public void QuitGame()
    {
        buttoClick.Play();
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        buttoClick.Play();
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;

    }

}