using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicPanelOnLevelChoice : MonoBehaviour
{
    public AudioSource buttonClick;

    public AudioMixerGroup soundMixer;
    public AudioMixerGroup musicMixer;

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


}
