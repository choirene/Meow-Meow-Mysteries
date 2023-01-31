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


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
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
        Debug.Log("End of Convo");
        dialoguePanel.SetActive(false);
        characterSprites[currentCharacter].SetActive(false);
    }

}
