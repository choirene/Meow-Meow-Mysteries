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
    public List<GameObject> characterSprites;
    public int currentId;
    public SolutionNPC currentNPC;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && playerInRange)
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

        currentId = currentNPC.id;
        characterSprites[currentId].SetActive(true);
        catDialogue.text = currentNPC.dialogue;
        accuseHeader.text = currentNPC.name + " was...";

    }

    public void EndDialogue()
    {
        accusePanel.SetActive(false);
        characterSprites[currentId].SetActive(false);
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
