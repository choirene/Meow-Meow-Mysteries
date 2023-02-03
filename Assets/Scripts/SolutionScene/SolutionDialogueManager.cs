using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolutionDialogueManager : MonoBehaviour
{
    bool playerInRange;
    public GameObject accusePanel;
    public TMP_Text catDialogue;
    public TMP_Text accuseHeader;
    public GameObject characterSprite;
    // public List<GameObject> characterSprites;
    public SolutionNPC currentNPC;
    public bool accused;
    public ClickSubmit submitButton;
    


    void Start()
    {
        accused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && playerInRange && !accused)
        {
            StartDialogue();
        }
    }
    public void StartDialogue ()
    {
        if(!accusePanel.activeInHierarchy)
        {
            accusePanel.SetActive(true);
        }
        submitButton.catId = currentNPC.id;
        characterSprite.SetActive(true);
        catDialogue.text = currentNPC.dialogue;
        accuseHeader.text = currentNPC.name + " was...";

    }

    public void EndDialogue()
    {
        accusePanel.SetActive(false);
        characterSprite.SetActive(false);
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
