using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionAndHintData : MonoBehaviour
{
    SolutionGenerator solution = new SolutionGenerator();
    HintGenerator hintGenerator = new HintGenerator();
    public List<string> convertedHintList = new List<string>();
    public List<List<string>> solutionList = new List<List<string>>();
    public GameObject displayHints;

    void Awake() 
    {
        solutionList = solution.generateSolution();
    }
    void Start()
    {
        InitialHintGeneration();
    }
    void Update()
    {
        
    }

    void InitialHintGeneration()
    {
        while(convertedHintList.Count < 4)
        {
            Hint newHint = hintGenerator.TwoToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateHint(convertedHint);
            if(flag)
            {
                convertedHintList.Add(convertedHint);
            }
        }
        while(convertedHintList.Count < 6)
        {
            Hint newHint = hintGenerator.OneToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateHint(convertedHint);
            if(flag)
            {
                convertedHintList.Add(convertedHint);                
            }
        }
    }

    public void GenerateRandomHint()
    {
        int type = Random.Range(0,5);
        if(type == 0)
        {
            Hint newHint = hintGenerator.OneToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateHint(convertedHint);
            while(!flag)
            {
                newHint = hintGenerator.OneToOneHintGenerator(solutionList);
                convertedHint = newHint.ConvertToDialogue();
                flag = ValidateHint(convertedHint);
            }
            convertedHintList.Add(convertedHint);
        }
        else
        {
            Hint newHint = hintGenerator.TwoToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateHint(convertedHint);
            while(!flag)
            {
                newHint = hintGenerator.TwoToOneHintGenerator(solutionList);
                convertedHint = newHint.ConvertToDialogue();
                flag = ValidateHint(convertedHint);
            }
            convertedHintList.Add(convertedHint);
        }

        // displayHints.GetComponent<DisplayHints>().UpdateHints(convertedHintList);
        // FIGURE OUT HOW TO LIVE UPDATE THE HINTS LIST TMP
    }

    public bool ValidateHint(string hint)
    {
        if(!convertedHintList.Contains(hint))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}