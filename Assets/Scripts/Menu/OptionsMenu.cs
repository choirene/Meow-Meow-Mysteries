using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject creditsPanel;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
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
