using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccusationManager : MonoBehaviour
{
    List<List<string>> solutionList;
    public int accusationsMade;
    public bool correctSolution;

    void Start()
    {
        solutionList = SolutionAndHintData.GetInstance().solutionList;
        accusationsMade = 0;
        correctSolution = true;
    }

    public void FinalAccusation(List<List<string>> accusationList)
    {
        string solutionString = "";
        foreach(var solution in solutionList)
        {
            foreach(var thing in solution)
            {
                solutionString = solutionString + thing;
            }
        }
        string accusationString = "";
        foreach(var accusation in accusationList)
        {
            foreach(var thing in accusation)
            {
                accusationString = accusationString + thing;
            }
        }
        Debug.Log(solutionString);
        Debug.Log(accusationString);



        // for(int i = 0; i < 5; i++)
        // {
        //     for(int j = 0; i < 3; i++)
        //     {
        //         if(solutionList[i][j] != accusationList[i][j])
        //         {
        //             correctSolution = false;
        //         }

        //     }
        // }

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
