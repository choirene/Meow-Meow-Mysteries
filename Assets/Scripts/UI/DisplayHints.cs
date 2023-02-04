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
        UpdateHints();
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
