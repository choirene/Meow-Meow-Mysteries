using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    // queue fifo collection

    public GameObject dialoguePanel;
    public List<GameObject> characterSprites;
    public int currentCharacter;
    public TMP_Text textComponent;

    public Dialogue dialogue;
    public bool playerInRange;
    public bool dialogueStarted;

    enum State 
    {
        greeting,
        askForAction,
        beg,
        playGame,
        bribe,
        translate,
        afterClue,
        goodbye
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
                StartDialogue(dialogue);
                dialogueStarted = true;
            }
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        if(!dialoguePanel.activeInHierarchy)
        {
            dialoguePanel.SetActive(true);
        }

        currentCharacter = dialogue.id;
        characterSprites[currentCharacter].SetActive(true);

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        textComponent.text = sentence;
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
