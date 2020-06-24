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
            musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        }
        else if (PlayerPrefs.GetInt("MusicEnabled") == 2)
        {
            musicMixer.audioMixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        }

        if (PlayerPrefs.GetInt("SoundEnabled") == 1)
        {
            soundMixer.audioMixer.SetFloat("SoundVolume", 0);
        }
        else if (PlayerPrefs.GetInt("MusicEnabled") == 2)
        {
            soundMixer.audioMixer.SetFloat("SoundVolume", -80);
        }
        else
        {
            soundMixer.audioMixer.SetFloat("SoundVolume", 0);
        }
    }

    public void ButtonSound()
    {
        buttonClick.Play();
    }

    public void MusicOnBtn()
    {
        buttonClick.Play();
        MusicOff.SetActive(true);
        PlayerPrefs.SetInt("MusicEnabled", 2);
        musicMixer.audioMixer.SetFloat("MusicVolume", -80);
        MusicOn.SetActive(false);
    }

    public void MusicOffBtn()
    {
        buttonClick.Play();
        PlayerPrefs.SetInt("MusicEnabled", 1);
        MusicOff.SetActive(false);
        musicMixer.audioMixer.SetFloat("MusicVolume", 0);
        MusicOn.SetActive(true);
    }


    public void SoundOnBtn()
    {
        buttonClick.Play();
        PlayerPrefs.SetInt("SoundEnabled", 2);
        SoundOff.SetActive(true);
        musicMixer.audioMixer.SetFloat("SoundVolume", -80);
        SoundOn.SetActive(false);
    }

    public void SoundOffBtn()
    {
        buttonClick.Play();
        PlayerPrefs.SetInt("SoundEnabled", 1);
        SoundOff.SetActive(false);
        musicMixer.audioMixer.SetFloat("SoundVolume", 0);
        SoundOn.SetActive(true);
    }
}
