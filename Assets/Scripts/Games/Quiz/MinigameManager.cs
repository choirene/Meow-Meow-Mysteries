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

    // hold the movement script/player game object
    // references to each mini game object & script
    // ability to call each mini game and close each minigame
    // have a bool true or false if the player is in a game... so i can turn on/off the movement and dialogue manager
    // on win, send back to the dialogue manager that the player earned a clue

    public void StartGame(int catId)
    {
        dialoguePanel.SetActive(false);
        currentId = catId;
        player.GetComponent<Movement>().enabled = false;
        games[catId].SetActive(true);
        switch(catId)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                games[catId].GetComponent<Quiz>().StartGame();
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
