using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownSelect : MonoBehaviour
{
    public int selection;
    public void SelectOption(int index)
    {
        selection = index;
    }
}
