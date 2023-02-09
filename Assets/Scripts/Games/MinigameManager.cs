using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] games;
    [SerializeField] DialogueManager[] dialogueManagers;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] AudioSource mainAudio;
    [SerializeField] AudioSource gameAudio;
    int currentId;

    private void Start() {
        mainAudio.GetComponent<AudioClip>();
    }
    public void StartGame(int catId)
    {
        StartCoroutine(FadeTrack(mainAudio, gameAudio));

        dialoguePanel.SetActive(false);
        currentId = catId;
        player.GetComponent<Movement>().enabled = false;
        games[catId].SetActive(true);
        switch(catId)
        {
            case 0:
                games[catId].GetComponent<MontyHall>().StartGame();
                break;
            case 1:
                games[catId].GetComponent<KaraokeClicker>().StartGame();
                break;
            case 2:
                games[catId].GetComponent<Quiz>().StartGame();
                break;
            case 3:
                games[catId].GetComponent<Blackjack>().StartGame();
                break;
            case 4:
                games[catId].GetComponent<HigherOrLower>().StartGame();
                break;
        }
    }

    public void CloseGame(bool winGame)
    {
        StartCoroutine(FadeTrack(gameAudio, mainAudio));

        dialoguePanel.SetActive(true);
        player.GetComponent<Movement>().enabled = true;
        games[currentId].SetActive(false);
        if(winGame)
        {
            dialogueManagers[currentId].WinGame();
        }
        else
        {
            dialogueManagers[currentId].LoseGame();
        }
    }

    private IEnumerator FadeTrack(AudioSource stopAudio, AudioSource startAudio)
    {
        float timeToFade = .9f;
        float timeElapsed = 0;

        startAudio.Play();

        while(timeElapsed < timeToFade)
        {
            stopAudio.volume = Mathf.Lerp(.5f, 0, timeElapsed/timeToFade);
            startAudio.volume = Mathf.Lerp(0, .5f, timeElapsed/timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        stopAudio.Stop();
    }

}
