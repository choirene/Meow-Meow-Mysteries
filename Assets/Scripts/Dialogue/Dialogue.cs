using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Dialogue
{
    public string name;
    public int id;
    [TextArea(2,4)] public string[] sentences;

    // [TextArea(3, 5)] [SerializeField] string[] greetings;
    // [TextArea(3,5)] [SerializeField] string askForAction;
    // [TextArea(3,5)] [SerializeField] string[] reactions;

}
