using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccusationManager : MonoBehaviour
{
    List<List<string>> solutionList;
    public int accusationsMade;
    string solutionString;

    void Start()
    {
        solutionList = SolutionAndHintData.GetInstance().solutionList;
        accusationsMade = 0;
        solutionString = "";
        foreach(var solution in solutionList)
        {
            foreach(var thing in solution)
            {
                solutionString = solutionString + thing;
            }
        }
        Debug.Log(solutionString);
    }

    public void FinalAccusation(List<List<string>> accusationList)
    {
        string accusationString = "";
        foreach(var accusation in accusationList)
        {
            foreach(var thing in accusation)
            {
                accusationString = accusationString + thing;
            }
        }
        Debug.Log(accusationString);

        if(solutionString == accusationString)
        {
            Debug.Log("you win!");
            // win scene
        }
        else
        {
            Debug.Log("You lose!");
            // lose scene
        }

    }
}
