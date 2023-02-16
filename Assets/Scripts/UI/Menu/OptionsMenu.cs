using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject creditsPanel;
    public Slider volumeSlider;
    private void Start() 
    {
        audioMixer.GetFloat("volume", out float currentVolume);
        volumeSlider.value = currentVolume;
    }
    public void SetVolume(float volume)
    {
        if(volume == -40)
        {
            audioMixer.SetFloat("volume", -80);
        }
        else
        {
            audioMixer.SetFloat("volume", volume);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ClickCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
}
