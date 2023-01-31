using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Dialogue
{
    public string name;
    public int id;
    [TextArea(2,4)] public string[] sentences;

    [TextArea(3, 5)] [SerializeField] public string[] greetings;
    [TextArea(3,5)] [SerializeField] public string askForAction;
    [TextArea(3, 5)] [SerializeField] public string[] beg;
    [TextArea(3, 5)] [SerializeField] public string[] playGame;
    [TextArea(3, 5)] [SerializeField] public string[] bribe;
    [TextArea(3, 5)] [SerializeField] public string[] translate;
    [TextArea(3,5)] [SerializeField] public string afterClue;
    [TextArea(3,5)] [SerializeField] public string goodbye;
    

    // [TextArea(3,5)] [SerializeField] string[] reactions;

}
