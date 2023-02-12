using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMarkToggle : MonoBehaviour
{
    [SerializeField] public List<GameObject> markSprites;
    public int currentMark;

    public void ToggleMark()
    {
        currentMark ++;
        currentMark = currentMark % 3;

        if(currentMark == 0)
        {
            markSprites[2].SetActive(false);
        }

        for(int i = 1; i < 3; i++)
        {
            if(i == currentMark)
            {
                markSprites[i-1].SetActive(false);
                markSprites[i].SetActive(true);
            }
        }
    }
    void Start()
    {
        currentMark = 0;
    }
}
