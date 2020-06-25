using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PauseMenuMixer : MonoBehaviour
{
    public AudioSource buttonClick;

    public AudioMixerGroup soundMixer;
    public AudioMixerGroup musicMixer;


    public GameObject MusicOn;
    public GameObject MusicOff;
    public GameObject SoundOff;
    public GameObject SoundOn;

    void Start()
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

    public void ButtonSound()
    {
        buttonClick.Play();
    }

    public void MusicOnBtn()
    {
        MusicOff.SetActive(true);
        PlayerPrefs.SetInt("MusicEnabled", 2);
        musicMixer.audioMixer.SetFloat("MusicVolume", -80);
        MusicOn.SetActive(false);
    }

    public void MusicOffBtn()
    {
        PlayerPrefs.SetInt("MusicEnabled", 1);
        MusicOff.SetActive(false);
        musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        MusicOn.SetActive(true);
    }


    public void SoundOnBtn()
    {
        PlayerPrefs.SetInt("SoundEnabled", 2);
        SoundOff.SetActive(true);
        musicMixer.audioMixer.SetFloat("SoundVolume", -80);
        SoundOn.SetActive(false);
    }

    public void SoundOffBtn()
    {
        PlayerPrefs.SetInt("SoundEnabled", 1);
        SoundOff.SetActive(false);
        musicMixer.audioMixer.SetFloat("SoundVolume", 0);
        SoundOn.SetActive(true);
    }
}
