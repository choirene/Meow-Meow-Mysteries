using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideBarUI : MonoBehaviour
{
    public bool isPanelActive;
    public GameObject activePanel;

    void Start()
    {
        isPanelActive = false;
        activePanel = null;
    }
}
