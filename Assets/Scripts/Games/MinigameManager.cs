using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] games;
    [SerializeField] DialogueManager[] dialogueManagers;
    [SerializeField] GameObject dialoguePanel;
    int currentId;

    public void StartGame(int catId)
    {
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

}
