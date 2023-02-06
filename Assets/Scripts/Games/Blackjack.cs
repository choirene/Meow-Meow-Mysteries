using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blackjack : MonoBehaviour
{
    [SerializeField] PlayingCard[] deck;
    [SerializeField] Sprite facedownSprite;
    [SerializeField] GameObject[] playerCards;
    [SerializeField] GameObject[] dealerCards;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject continueButton;
    int playerScore;
    int dealerScore;
    List<PlayingCard> playerHand = new List<PlayingCard>();
    List<PlayingCard> dealerHand = new List<PlayingCard>();
    List<PlayingCard> cardList = new List<PlayingCard>();

    public void StartGame()
    {
        buttonsPanel.SetActive(true);
        quitButton.SetActive(false);
        nextButton.SetActive(false);
        continueButton.SetActive(false);

        for(int i = 2; i<5; i++)
        {
            playerCards[i].SetActive(false);
            dealerCards[i].SetActive(false);
        }

        cardList.Clear();
        List<int> indicesUsed = new List<int>();
        while(cardList.Count < 10)
        {
            int randomIndex = Random.Range(0,deck.Length);
            if(!indicesUsed.Contains(randomIndex))
            {
                indicesUsed.Add(randomIndex);
                cardList.Add(deck[randomIndex]);
            }
        }

        for(int i = 0; i<5; i++)
        {

        }


    }

    void CalculateScore()
    {

    }

    void ClickHit()
    {

    }

    void ClickStand()
    {

    }

}
