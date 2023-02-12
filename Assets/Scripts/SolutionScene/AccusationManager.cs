using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccusationManager : MonoBehaviour
{
    List<List<string>> solutionList;
    public int accusationsMade;
    string solutionString;
    public Animator transition;

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

        if(solutionString == accusationString)
        {
            StartCoroutine(CrossFade("WinScene"));
        }
        else
        {
            StartCoroutine(CrossFade("LoseScene"));
        }
    }

    IEnumerator CrossFade(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
