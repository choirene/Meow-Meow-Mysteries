using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blackjack : MonoBehaviour
{
    [SerializeField] PlayingCard[] deck;
    [SerializeField] Sprite facedownSprite;
    [SerializeField] GameObject[] playerCards;
    [SerializeField] GameObject[] dealerCards;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text dealerText;
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject continueButton;
    int playerHandSize;
    int dealerHandSize;
    int playerScore;
    int dealerScore;
    List<PlayingCard> playerBank = new List<PlayingCard>();
    List<PlayingCard> dealerBank = new List<PlayingCard>();

    public void StartGame()
    {
        buttonsPanel.SetActive(true);
        quitButton.SetActive(false);
        nextButton.SetActive(false);
        continueButton.SetActive(false);
        dealerText.text = "";

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

        for(int i = 0; i < 2; i++)
        {
            dealerCards[i].GetComponent<Image>().sprite = facedownSprite;
            playerCards[i].GetComponent<Image>().sprite = playerBank[i].cardSprite;
        }
        dealerCards[0].GetComponent<Image>().sprite = dealerBank[0].cardSprite;
        
        playerHandSize = 2;
        playerScore = CalculateScore(playerBank.GetRange(0,playerHandSize));
        scoreText.text = "Current Score: " + playerScore;
        if(playerScore == 21)
        {
            WinGame();
        }
    }

    public void ClickHit()
    {
        playerCards[playerHandSize].SetActive(true);
        playerCards[playerHandSize].GetComponent<Image>().sprite = playerBank[playerHandSize].cardSprite;
        playerHandSize ++;
        playerScore = CalculateScore(playerBank.GetRange(0,playerHandSize));
        scoreText.text = "Current Score: " + playerScore;
        if(playerScore > 21)
        {
            LoseGame();
            return;
        }

        if(playerHandSize == 5)
        {
            ClickStand();
        }
    }

    public void ClickStand()
    {
        buttonsPanel.SetActive(false);
        dealerText.text = "Dealer's turn";
        nextButton.SetActive(true);
        dealerCards[1].GetComponent<Image>().sprite = dealerBank[1].cardSprite;
        dealerHandSize = 2;
        dealerScore = CalculateScore(dealerBank.GetRange(0, dealerHandSize));
        scoreText.text = "Dealer Score: " + dealerScore + "\n Current Score: " + playerScore;
    }

    public void DealersTurn()
    {
        while((dealerScore < 17) && (dealerHandSize != 5))
        {
            dealerCards[dealerHandSize].SetActive(true);
            dealerCards[dealerHandSize].GetComponent<Image>().sprite = dealerBank[dealerHandSize].cardSprite;
            dealerHandSize ++;
            dealerScore = CalculateScore(dealerBank.GetRange(0, dealerHandSize));
            scoreText.text = "Dealer Score: " + dealerScore + "\n Current Score: " + playerScore;
                if(dealerScore > 21)
                {
                    nextButton.SetActive(false);
                    WinGame();
                    return;
                }
        }

        nextButton.SetActive(false);

        if(playerScore > dealerScore)
        {
            WinGame();
        }
        else 
        {
            LoseGame();
        }
    }

    void LoseGame()
    {
        buttonsPanel.SetActive(false);
        dealerText.text = "You lose...";
        quitButton.SetActive(true);
    }

    void WinGame()
    {
        buttonsPanel.SetActive(false);
        dealerText.text = "You win!";
        continueButton.SetActive(true);
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
}
