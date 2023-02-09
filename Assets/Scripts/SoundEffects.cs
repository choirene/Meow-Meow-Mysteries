using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] AudioClip[] soundEffects;
    [SerializeField] AudioSource audioSource;
    public static SoundEffects instance;
    private void Start() 
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static SoundEffects GetInstance()
    {
        return instance;
    }

    public void PlayMeow()
    {
        audioSource.clip = soundEffects[0];
        audioSource.Play();
    }

    public void PlayAlarm()
    {
        audioSource.clip = soundEffects[1];
        audioSource.Play();
    }

    public void PlayWinSound()
    {
        audioSource.clip = soundEffects[2];
        audioSource.Play();
    }

    public void PlayLoseSound()
    {
        audioSource.clip = soundEffects[3];
        audioSource.Play();
    }

}
