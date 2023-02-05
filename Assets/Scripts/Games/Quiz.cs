using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO[] questionBank;
    [SerializeField] GameObject[] answerButtons;
    List<QuestionSO> questionList = new List<QuestionSO>(); 
    int correctAnswerIndex;
    int currentQuestionIndex;


    void Start()
    {
        List<int> indicesUsed = new List<int>();
        while(questionList.Count < 3)
        {
            int randomIndex = Random.Range(0,questionBank.Length);
            if(!indicesUsed.Contains(randomIndex))
            {
                indicesUsed.Add(randomIndex);
                questionList.Add(questionBank[randomIndex]);
            }
        }
        currentQuestionIndex = 0;
        NextQuestion();
    }

    public void SelectAnswer(int index)
    {
        // these do not show up bc it immediately calls next question.....
        if(index == correctAnswerIndex)
        {
            questionText.text = "How? ...Yes that's correct.";
        }
        else
        {
            questionText.text = "HA HA STINKER. The correct answer was " + questionList[currentQuestionIndex].GetAnswer(correctAnswerIndex);
            LoseGame();
            return;
        }

        currentQuestionIndex ++;

        if(currentQuestionIndex == questionList.Count)
        {
            WinGame();
        }
        else
        {
            NextQuestion();
        }
    }

    public void NextQuestion()
    {
        questionText.text = questionList[currentQuestionIndex].GetQuestion();
        correctAnswerIndex = questionList[currentQuestionIndex].GetCorrectAnswerIndex();
        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionList[currentQuestionIndex].GetAnswer(i);
        }
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
    }

}
