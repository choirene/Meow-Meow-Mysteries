using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class SolutionNPC
{
    public string name;
    public int id;
    [TextArea(3,5)] [SerializeField] public string dialogue;

}
