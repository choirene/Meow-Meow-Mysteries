using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerInteraction : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject characterSprite;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    bool playerInRange;
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
                dialogueText.text = furnitureData.flavorText;
                int randomInt = Random.Range(0,1);
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
                int randomItem = Random.Range(0, furnitureData.potentialYields.Length);
                Debug.Log("you found a " + randomItem);
                // add inventory code
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
        dialoguePanel.SetActive(false);
        characterSprite.SetActive(false);
        nameText.text = "";
        currentState = State.notActive;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
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
        if(other.CompareTag("Furniture"))
        {
            playerInRange = false;
            EndInteraction();
        }
    }

}
