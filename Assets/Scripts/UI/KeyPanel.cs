using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanel : MonoBehaviour
{
    public GameObject keyPanel;
    public GameObject instructions;
    public List<GameObject> keys;
    int currentKey;
    bool activeSelection;

    private void Start() 
    {
        currentKey = -1;
    }
    public void OpenKey()
    {
        keyPanel.SetActive(true);
    }
    public void CloseKey()
    {
        keyPanel.SetActive(false);
    }

    public void ClickCategoryKey(int newKey)
    {
        if(currentKey == newKey)
        {
            instructions.SetActive(true);
            keys[currentKey].SetActive(false);
            currentKey = -1;
            activeSelection = false;
        }
        else
        {
            if(activeSelection)
            {
                keys[currentKey].SetActive(false);
            }
            instructions.SetActive(false);
            currentKey = newKey;
            keys[currentKey].SetActive(true);
            activeSelection = true;
        }
    }

}
