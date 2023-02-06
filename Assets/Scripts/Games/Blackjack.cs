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
    List<PlayingCard> playerBank = new List<PlayingCard>();
    List<PlayingCard> dealerBank = new List<PlayingCard>();

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

        playerBank.Clear();
        dealerBank.Clear();
        List<int> indicesUsed = new List<int>();
        while(playerBank.Count < 5)
        {
            int randomIndex = Random.Range(0,deck.Length);
            if(!indicesUsed.Contains(randomIndex))
            {
                indicesUsed.Add(randomIndex);
                playerBank.Add(deck[randomIndex]);
            }
        }
        while(dealerBank.Count < 5)
        {
            int randomIndex = Random.Range(0,deck.Length);
            if(!indicesUsed.Contains(randomIndex))
            {
                indicesUsed.Add(randomIndex);
                dealerBank.Add(deck[randomIndex]);
            }
        }
    }

    int CalculateScore(List<PlayingCard> hand)
    {
        int score = 0;
        int acesCount = 0;

        foreach(var card in hand)
        {
            if(card.isAce)
            {
                acesCount ++;
            }
            else
            {
                score = score + card.blackjackValue;
            }
        }

        if(acesCount > 0)
        {
            if((acesCount + score) > 21)
            {
                return (acesCount + score);
            }
            for(int i = acesCount; i > 0; i = i -1)
            {
                int leftoverAces = acesCount - i;
                int potentialScore = (i * 11) + (score + leftoverAces);
                if(potentialScore <= 21)
                {
                    score = potentialScore;
                    return score;
                }
            }
        }

        return score;
    }

    void ClickHit()
    {

    }

    void ClickStand()
    {

    }

}
