using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject menuPanel;

    public void TogglePanel()
    {
        if(!menuPanel.activeSelf)
		{
			menuPanel.SetActive(true);
		}
		else
		{
			menuPanel.SetActive(false);
		}
    }
}
