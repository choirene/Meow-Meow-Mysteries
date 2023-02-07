using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HigherOrLower : MonoBehaviour
{
    [SerializeField] PlayingCard[] deck;
    [SerializeField] Sprite facedownCard;
    [SerializeField] Image playerCardSprite;
    [SerializeField] Image nextCardSprite;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject continueButton;

    List<PlayingCard> cardList = new List<PlayingCard>();
    int playerCard;
    int nextCard;

    public void StartGame()
    {
        buttonsPanel.SetActive(true);
        endPanel.SetActive(false);
        quitButton.SetActive(false);
        nextButton.SetActive(false);
        continueButton.SetActive(false);
        text.text = "The next card will be...";

        cardList.Clear();
        List<int> indicesUsed = new List<int>();
        while(cardList.Count < 6)
        {
            int randomIndex = Random.Range(0,deck.Length);
            if(!indicesUsed.Contains(randomIndex))
            {
                indicesUsed.Add(randomIndex);
                cardList.Add(deck[randomIndex]);
            }
        }
        playerCard = 0;
        nextCard = 1;
        playerCardSprite.sprite = cardList[playerCard].cardSprite;
        nextCardSprite.sprite = facedownCard;
    }

    public void NextRound()
    {
        buttonsPanel.SetActive(true);
        nextButton.SetActive(false);
        text.text = "The next card will be...";

        playerCard = playerCard + 2;
        nextCard = nextCard + 2;

        playerCardSprite.sprite = cardList[playerCard].cardSprite;
        nextCardSprite.sprite = facedownCard;
    }

    public void ClickHigher()
    {
        if(cardList[nextCard].holValue > cardList[playerCard].holValue)
        {
            WinRound();
        }
        else
        {
            LoseRound();
        }
    } 

    public void ClickLower()
    {
        if(cardList[nextCard].holValue < cardList[playerCard].holValue)
        {
            WinRound();
        }
        else
        {
            LoseRound();
        }
    }

    void WinRound()
    {
        nextCardSprite.sprite = cardList[nextCard].cardSprite;
        buttonsPanel.SetActive(false);

        if(nextCard == 5)
        {
            continueButton.SetActive(true);
            text.text = "Congrats!";
        }
        else
        {
            nextButton.SetActive(true);
            text.text = "You win this round!";
        }
    }

    void LoseRound()
    {
        buttonsPanel.SetActive(false);
        endPanel.SetActive(true);
        quitButton.SetActive(true);
        nextCardSprite.sprite = cardList[nextCard].cardSprite;
        text.text = "Too bad.";
    }
}
