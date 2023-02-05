using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] MinigameManager minigameManager;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO[] questionBank;
    [SerializeField] GameObject[] answerButtons;
    List<QuestionSO> questionList = new List<QuestionSO>(); 
    int correctAnswerIndex;
    int currentQuestionIndex;


    public void StartGame()
    {
        questionList.Clear();
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
        if(index != correctAnswerIndex)
        {
            minigameManager.CloseGame(false);
            return;
        }

        currentQuestionIndex ++;

        if(currentQuestionIndex == questionList.Count)
        {
            minigameManager.CloseGame(true);
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

}
