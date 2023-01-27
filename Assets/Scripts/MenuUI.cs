using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject menuPanel;
    public RightSideBarUI sideBarUI;
    public void TogglePanel()
    {
        if(!menuPanel.activeSelf)
		{
            if(!sideBarUI.isPanelActive)
            {
                sideBarUI.isPanelActive = true;
            }
            else if(sideBarUI.isPanelActive)
            {
                sideBarUI.activePanel.SetActive(false);
            }

			menuPanel.SetActive(true);
            sideBarUI.activePanel = menuPanel;

		}
		else
		{
			menuPanel.SetActive(false);
            sideBarUI.isPanelActive = false;
            sideBarUI.activePanel = null;
		}
    }
}
