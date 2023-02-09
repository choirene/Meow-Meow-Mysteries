using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MontyHall : MonoBehaviour
{
    [SerializeField] Image[] catGameObjects;
    [SerializeField] Image[] closedDoors;

    [Header("Buttons")]
    [SerializeField] GameObject switchButton;
    [SerializeField] GameObject keepButton;
    [SerializeField] GameObject winButton;
    [SerializeField] GameObject loseButton;
    [SerializeField] GameObject playAgainButton;
    [Header("Text")]
    [SerializeField] GameObject beginningText;
    [SerializeField] GameObject switchText;
    [SerializeField] GameObject switchDoorsText;
    [SerializeField] GameObject endText;
    private int cocoIndex;
    private bool choiceActive;
    private int doorChoiceIndex;
    private bool secondChoice;

    public void StartGame()
    {
        switchButton.SetActive(false);
        keepButton.SetActive(false);
        winButton.SetActive(false);
        loseButton.SetActive(false);
        playAgainButton.SetActive(false);
        beginningText.SetActive(true);
        switchText.SetActive(false);
        switchDoorsText.SetActive(false);
        endText.SetActive(false);
        for(int i = 0; i < 5; i++)
        {
            catGameObjects[i].enabled = false;
            closedDoors[i].enabled = true;
        }
        int index = Random.Range(0,5);
        cocoIndex = index;
        catGameObjects[index].enabled = true;

        choiceActive = true;
        secondChoice = false;
    }

    public void ChooseDoor(int index)
    {
        if(choiceActive)
        {
            doorChoiceIndex = index;
            if(secondChoice)
            {
                EndGame();
            }
            else
            {
                AskSwitchDoor();
            }
        }

    }

    void AskSwitchDoor()
    {
        choiceActive =false;
        int randomIndex = Random.Range(0,5);
        while(randomIndex == cocoIndex || randomIndex == doorChoiceIndex)
        {
            randomIndex = Random.Range(0,5);
        }
        closedDoors[randomIndex].enabled = false;
        beginningText.SetActive(false);
        switchText.SetActive(true);
        switchButton.SetActive(true);
        keepButton.SetActive(true);
    }

    public void SwitchChoice()
    {
        switchText.SetActive(false);
        switchButton.SetActive(false);
        keepButton.SetActive(false);
        switchDoorsText.SetActive(true);
        choiceActive = true;
        secondChoice = true;
    }

    public void EndGame()
    {
        choiceActive = false;
        switchText.SetActive(false);
        switchButton.SetActive(false);
        keepButton.SetActive(false);
        switchDoorsText.SetActive(false);
        endText.SetActive(true);

        foreach(var door in closedDoors)
        {
            door.enabled = false;
        }
        if(doorChoiceIndex == cocoIndex)
        {
            SoundEffects.GetInstance().PlayWinSound();
            endText.GetComponent<TMP_Text>().text = "You found her!";
            winButton.SetActive(true);
        }
        else
        {
            SoundEffects.GetInstance().PlayLoseSound();
            endText.GetComponent<TMP_Text>().text = "She got away...";
            playAgainButton.SetActive(true);
            loseButton.SetActive(true);
        }
    }
}
