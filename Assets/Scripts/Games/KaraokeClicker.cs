using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class KaraokeClicker : MonoBehaviour
{
    [SerializeField] Slider basilSlider;
    [SerializeField] Slider percySlider;
    [SerializeField] Image rightTimerImage;
    [SerializeField] Image leftTimerImage;
    // [SerializeField] AudioSource soundEffects;
    // [SerializeField] AudioClip catMeow, alarmSound;
    [SerializeField] TMP_Text text;
    [Header("Buttons")]
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject winButton;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] GameObject quitButton;
    bool gameStarted;
    float timeLimit = 10f;
    float timerValue;
    float fillFraction;
    float basilClicks;
    public void StartGame()
    {
        basilClicks = 0;
        basilSlider.value = 0;
        percySlider.value = 0;
        rightTimerImage.fillAmount = 1;
        leftTimerImage.fillAmount = 1;
        text.text = "";
        startButton.SetActive(true);
        winButton.SetActive(false);
        playAgainButton.SetActive(false);
        quitButton.SetActive(false);
        gameStarted = false;
        timerValue = 10f;
    }

    public void PressStart()
    {
        gameStarted = true;
        startButton.SetActive(false);
        text.text = "Go!";
    }

    private void Update() 
    {
        if(gameStarted)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue > 0)
        {
            fillFraction = timerValue / timeLimit;
            rightTimerImage.fillAmount = fillFraction;
            leftTimerImage.fillAmount = fillFraction;
            basilClicks += (Time.deltaTime * (6.3f + Random.Range(0,.5f)));
            basilSlider.value = basilClicks;
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        SoundEffects.GetInstance().PlayAlarm();
        gameStarted = false;
        text.text = "";
        if(percySlider.value > basilSlider.value)
        {
            winButton.SetActive(true);
        }
        else
        {
            playAgainButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }

    public void ClickCat()
    {
        if(gameStarted)
        {
            if(percySlider.value < 80)
            {
                percySlider.value ++;
                SoundEffects.GetInstance().PlayMeow();
                if(percySlider.value < 10)
                {
                    text.text = "Better start singing!";
                }
                else if(percySlider.value < 25)
                {
                    text.text = "I can't hear you!";
                }
                else if(percySlider.value < 50)
                {
                    text.text = "Sing your heart out!";
                }
                else if(percySlider.value < 75)
                {
                    text.text = "You're almost there!";
                }
                else
                {
                    text.text = "You go Whitney Houston!";
                }
            }
        }
    }
}
