using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Playing Card", fileName = "Diamonds")]
public class PlayingCard : ScriptableObject
{
    public string title;
    public string suit;
    public int blackjackValue;
    public int holValue;
    public bool isAce;
    public Sprite cardSprite;
}
