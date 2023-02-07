using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontyHall : MonoBehaviour
{
    [SerializeField] Sprite[] catSprites;
    [SerializeField] GameObject[] closedDoors;

    public void StartGame()
    {
        Debug.Log("started");
    }
}
