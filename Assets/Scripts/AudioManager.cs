using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] soundtracks;
    [SerializeField] AudioSource mainAudioSource;
    [SerializeField] GameObject audioPanel;
    bool playerInRange;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && playerInRange)
        {
            audioPanel.SetActive(true);
        }
    }
    public void SelectTrack(int index)
    {
        mainAudioSource.clip = soundtracks[index];
        mainAudioSource.Play();
    }
    public void ClosePanel()
    {
        audioPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            ClosePanel();
        }
    }
}
