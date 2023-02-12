using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DisplayHints : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    List<string> hintList = new List<string>();
    void Start()
    {
        textComponent.text = "No clues? Time to investigate! \nSniff out your surroundings and talk to the suspects in order to solve the mystery. Once you gather some clues, they'll show up here!";
    }
    public void UpdateHints()
    {
        hintList = SolutionAndHintData.GetInstance().convertedHintList;

        string hintText = string.Empty;

        foreach(var hint in hintList)
        {
            hintText = hintText + "- " + hint + "\n";
        }
        textComponent.text = hintText;
    }

}
