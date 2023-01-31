using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    // queue fifo collection

    public GameObject dialoguePanel;
    public GameObject dialogueOptions;
    public List<GameObject> characterSprites;
    public int currentCharacter;
    public TMP_Text textComponent;

    public Dialogue dialogue;
    public bool playerInRange;
    public bool dialogueStarted;
    State currentState;

    enum State 
    {
        greeting,
        askForAction,
        beg,
        playGame,
        bribe,
        translate,
        afterClue,
        goodbye,
        end
    }

    void Start()
    {
        sentences = new Queue<string>();
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

        currentCharacter = dialogue.id;
        characterSprites[currentCharacter].SetActive(true);

        currentState = State.greeting;

        // sentences.Clear();
        // foreach(string sentence in dialogue.sentences)
        // {
        //     sentences.Enqueue(sentence);
        // }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        switch(currentState)
        {
            case State.greeting:
                int greetingIndex = Random.Range(0, dialogue.greetings.Length);
                textComponent.text = dialogue.greetings[greetingIndex];
                currentState = State.askForAction;
                break;
            case State.askForAction:
                textComponent.text = dialogue.askForAction;
                dialogueOptions.SetActive(true);
                break;
            case State.beg:
                break;
            case State.goodbye:
                textComponent.text = dialogue.goodbye;
                currentState = State.end;
                break;
            case State.end:
                EndDialogue();
                break;
            default:
                Debug.Log("ioasjdf");
                break;

        }

        // if(sentences.Count == 0)
        // {
        //     EndDialogue();
        //     return;
        // }

        // string sentence = sentences.Dequeue();
        // textComponent.text = sentence;
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

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        characterSprites[currentCharacter].SetActive(false);
        dialogueStarted = false;
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
