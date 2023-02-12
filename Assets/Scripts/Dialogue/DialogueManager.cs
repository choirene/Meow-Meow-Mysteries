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
    [SerializeField] GameObject gameOptions;
    [SerializeField] GameObject bribePanel;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject bribeQuitButton;
    [SerializeField] TMP_Text bribeConfirmText;
    [SerializeField] DisplayHints hintDisplay;
    ItemSO bribeItem;
    public GameObject characterSprite; 
    public TMP_Text nameText;
    public ClickDialogueOption choiceButtons;
    public TMP_Text textComponent;
    bool atCapacity;
    public Dialogue dialogue;
    [SerializeField] MinigameManager minigameManager;
    bool inGame;
    State currentState;

    enum State 
    {
        greeting,
        askForAction,
        beg,
        playGame,
        startGame,
        winGame,
        loseGame,
        bribe,
        acceptBribe,
        rejectBribe,
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
        if(Input.GetKeyDown(KeyCode.X) && playerInRange && !inGame)
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
        if(SolutionAndHintData.GetInstance().atCapacity)
        {
            atCapacity = true;
        }

        if(!dialoguePanel.activeInHierarchy)
        {
            dialoguePanel.SetActive(true);
        }

        menu.SetActive(false);

        characterSprite.SetActive(true);
        nameText.text = dialogue.name;
        choiceButtons.catId = dialogue.id;

        SoundEffects.GetInstance().PlayMeow();

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
                textComponent.text = dialogue.playGame;
                gameOptions.SetActive(true);
                break;
            case State.startGame:
                inGame = true;
                minigameManager.StartGame(dialogue.id);
                break;
            case State.winGame:
                inGame = false;
                textComponent.text = dialogue.winGame;
                currentState = State.showClue;
                break;
            case State.loseGame:
                inGame = false;
                textComponent.text = dialogue.loseGame;
                currentState = State.askForAction;
                break;
            case State.bribe:
                textComponent.text = dialogue.bribe[0];
                bribePanel.SetActive(true);
                bribeQuitButton.SetActive(true);
                break;
            case State.acceptBribe:
                textComponent.text = dialogue.bribe[1];
                currentState = State.showClue;
                break;
            case State.rejectBribe:
                textComponent.text = dialogue.bribe[2];
                currentState = State.askForAction;
                break;
            case State.showClue:
                ShowClue();
                currentState = State.afterClue;
                break;
            case State.noMoreClues:
                textComponent.text = dialogue.noMoreClues;
                currentState = State.end;
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

    public void ClickPlay()
    {
        currentState = State.playGame;
        dialogueOptions.SetActive(false);
        DisplayNextSentence();
    }

    public void ClickBribe()
    {
        currentState = State.bribe;
        dialogueOptions.SetActive(false);
        DisplayNextSentence();
    }

    public void PickItem(ItemSO selectedItem)
    {
        bribeItem = selectedItem;
        bribeQuitButton.SetActive(false);
        confirmPanel.SetActive(true);
        bribeConfirmText.text = "Give " + dialogue.name + " " + bribeItem.itemName + "?";
    }

    public void ConfirmItem(bool response)
    {
        if(response)
        {
            confirmPanel.SetActive(false);
            bribePanel.SetActive(false);
            if(bribeItem.pickyFactor <= dialogue.pickyIndex)
            {
                currentState = State.acceptBribe;
                Inventory.GetInstance().RemoveItem(bribeItem.id);
            }
            else
            {
                currentState = State.rejectBribe;
            }
            DisplayNextSentence();
        }
        else
        {
            bribeItem = null;
            confirmPanel.SetActive(false);
        }
    }
    public void ClickStart()
    {
        currentState = State.startGame;
        gameOptions.SetActive(false);
        DisplayNextSentence();
    }

    public void QuitGame()
    {
        currentState = State.askForAction;
        gameOptions.SetActive(false);
        DisplayNextSentence();
    }
    public void WinGame()
    {
        currentState = State.winGame;
        DisplayNextSentence();
    }

    public void LoseGame()
    {
        currentState = State.loseGame;
        DisplayNextSentence();
    }

    public void ClickQuit()
    {
        bribePanel.SetActive(false);
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
        hintDisplay.UpdateHints();
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueOptions.SetActive(false);
        gameOptions.SetActive(false);
        bribePanel.SetActive(false);
        bribeQuitButton.SetActive(false);
        confirmPanel.SetActive(false);
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
