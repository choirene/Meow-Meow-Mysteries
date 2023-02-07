using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaraokeClicker : MonoBehaviour
{
    [SerializeField] Slider basilSlider;
    [SerializeField] Slider percySlider;
    float timeLimit = 10f;
    float timerValue;
    public void StartGame()
    {
        basilSlider.value = 0;
        percySlider.value = 0;
    }

    public void ClickCat()
    {
        if(percySlider.value <= 100)
        {
            percySlider.value ++;
        }
    }
}
