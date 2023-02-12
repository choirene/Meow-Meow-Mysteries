using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerInteraction : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject characterSprite;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Rigidbody2D rbPlayer;
    bool playerInRange;
    bool npcInRange;
    bool rbInRange;
    FurnitureSO furnitureData;
    State currentState;

    enum State
    {
        notActive,
        active,
        startedInteraction,
        discovery,
        foundItem,
        end
    }
    void Start()
    {
        currentState = State.notActive;
    }

    void Update()
    {
        if(npcInRange)
        {
            currentState = State.notActive;
        }
        if(Input.GetKeyDown(KeyCode.X) && playerInRange)
        {
            if(currentState == State.active)
            {
                StartInteraction();
            }
            else
            {
                ContinueInteraction();
            }
        }
        if(rbInRange && rbPlayer.IsSleeping())
        {
            rbPlayer.WakeUp();
        }
    }
    void StartInteraction()
    {
        dialoguePanel.SetActive(true);
        characterSprite.SetActive(true);
        nameText.text = "Percy";

        currentState = State.startedInteraction;
        ContinueInteraction();
    }
    void ContinueInteraction()
    {
        switch(currentState)
        {
            case State.startedInteraction:
                player.GetComponent<Movement>().StopMovement();
                player.GetComponent<Movement>().enabled = false;
                dialogueText.text = furnitureData.flavorText;
                int randomInt = Random.Range(0,2);
                if(furnitureData.yieldPossible && randomInt == 0)
                {
                    currentState = State.discovery;
                }
                else
                {
                    currentState = State.end;
                }
                break;
            case State.discovery:
                dialogueText.text = "Huh? What's this...";
                currentState = State.foundItem;
                break;
            case State.foundItem:
                SoundEffects.GetInstance().PlayWinSound();
                int randomItem = Random.Range(0, furnitureData.potentialYields.Length);
                ItemSO item = furnitureData.potentialYields[randomItem];
                dialogueText.text = "You found " + item.itemName + "!";
                Inventory.GetInstance().AddItem(item.id);
                furnitureData.yieldPossible = false;
                currentState = State.end;
                break;
            case State.end:
                EndInteraction();
                break;
        }
    }
    void EndInteraction()
    {
        player.GetComponent<Movement>().enabled = true;
        dialoguePanel.SetActive(false);
        characterSprite.SetActive(false);
        nameText.text = "";
        currentState = State.notActive;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("NPC"))
        {
            npcInRange = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        rbInRange = true;
        if(other.CompareTag("Furniture"))
        {
            if(currentState == State.notActive)
            {
                playerInRange = true;
                furnitureData = other.GetComponent<Interactable>().furnitureData;
                currentState = State.active;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("NPC"))
        {
            npcInRange = false;
        }
        if(other.CompareTag("Furniture"))
        {
            playerInRange = false;
            rbInRange = false;
            EndInteraction();
        }
    }

}
