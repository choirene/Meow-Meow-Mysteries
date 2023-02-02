using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SelectSuspect : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    string defaultText = "Click on a suspect to learn more about their wickedness.";
    [TextArea(10,14)] public List<string> suspectText;
    bool activeSelection;
    int currentCat;
    Animator currentAnimator;

    private void Start() {
        activeSelection = false;
        currentCat = -1;
    }

    public void PickSuspect(SuspectButton suspect)
    {
        if(activeSelection)
        {
            currentAnimator.SetBool("isPressed", false);
        }

        if(suspect.catId == currentCat)
        {
            activeSelection = false;
            textComponent.text = defaultText;
            currentCat = -1;
        }
        else
        {
            activeSelection = true;
            currentAnimator = suspect.animator;
            currentCat = suspect.catId;

            currentAnimator.SetBool("isPressed", true);
            textComponent.text = suspect.suspectText;
        }
    }

}
