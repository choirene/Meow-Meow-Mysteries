using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public bool playerInRange;
    public bool dialogueStarted;
    public GameObject menu;
    public GameObject dialoguePanel;
    public GameObject dialogueOptions;
    public GameObject characterSprite; 
    public ClickDialogueOption choiceButtons;
    public TMP_Text textComponent;
    bool atCapacity;
    public Dialogue dialogue;
    State currentState;

    enum State 
    {
        greeting,
        askForAction,
        beg,
        playGame,
        bribe,
        translate,
        showClue,
        afterClue,
        noMoreClues,
        goodbye,
        end
    }

    void Start()
    {
        atCapacity = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && playerInRange)
        {
            if(dialogueStarted)
            {
                DisplayNextSentence();
            }
            else
            {
                StartDialogue();
                dialogueStarted = true;
            }
        }
    }

    public void StartDialogue ()
    {
        if(!dialoguePanel.activeInHierarchy)
        {
            dialoguePanel.SetActive(true);
        }

        menu.SetActive(false);

        characterSprite.SetActive(true);
        choiceButtons.catId = dialogue.id;

        currentState = State.greeting;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        switch(currentState)
        {
            case State.greeting:
                int greetingIndex = Random.Range(0, dialogue.greetings.Length);
                textComponent.text = dialogue.greetings[greetingIndex];
                if(atCapacity)
                {
                    currentState = State.noMoreClues;
                }
                else
                {
                    currentState = State.askForAction;
                }
                break;
            case State.askForAction:
                textComponent.text = dialogue.askForAction;
                dialogueOptions.SetActive(true);
                break;
            case State.beg:
                if(Random.Range(0,dialogue.unhelpfulIndex) == 0)
                {
                    textComponent.text = dialogue.beg[1];
                    currentState = State.showClue;
                }
                else
                {
                    textComponent.text = dialogue.beg[0];
                    currentState = State.askForAction;
                }
                break;
            case State.playGame:
                break;
            case State.bribe:
                break;
            case State.translate:
                break;
            case State.showClue:
                ShowClue();
                currentState = State.afterClue;
                break;
            case State.noMoreClues:
                textComponent.text = dialogue.noMoreClues;
                currentState = State.goodbye;
                break;
            case State.afterClue:
                textComponent.text = dialogue.afterClue;
                currentState = State.end;
                break;
            case State.goodbye:
                textComponent.text = dialogue.goodbye;
                currentState = State.end;
                break;
            case State.end:
                EndDialogue();
                break;
        }
    }
    public void ClickBeg()
    {
        currentState = State.beg;
        dialogueOptions.SetActive(false);
        DisplayNextSentence();
    }

    public void ClickQuit()
    {
        currentState = State.goodbye;
        dialogueOptions.SetActive(false);
        DisplayNextSentence();
    }

    public void ShowClue()
    {
        SolutionAndHintData solutionData = SolutionAndHintData.GetInstance();
        solutionData.GenerateRandomHint(dialogue.name);
        string lastHint = solutionData.convertedHintList[^1];
        textComponent.text = lastHint;
        if(solutionData.atCapacity)
        {
            atCapacity = true;
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        characterSprite.SetActive(false);
        dialogueStarted = false;
        menu.SetActive(true);
        choiceButtons.catId = -1;
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
            EndDialogue();
        }
    }


}
