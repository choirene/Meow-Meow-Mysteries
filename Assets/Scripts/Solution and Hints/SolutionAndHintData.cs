using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionAndHintData : MonoBehaviour
{
    public SolutionGenerator solution = new SolutionGenerator();
    HintGenerator hintGenerator = new HintGenerator();
    public List<string> convertedHintList = new List<string>();
    public List<List<string>> solutionList = new List<List<string>>();

    void Awake() 
    {
        solutionList = solution.generateSolution();
    }
    void Start()
    {
        InitialHintGeneration();
        foreach(var hint in convertedHintList)
        {
            Debug.Log(hint);
        }

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
            if(!convertedHintList.Contains(convertedHint))
            {
                convertedHintList.Add(convertedHint);
            }
        }
        while(convertedHintList.Count < 6)
        {
            Hint newHint = hintGenerator.OneToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            if(!convertedHintList.Contains(convertedHint))
            {
                convertedHintList.Add(convertedHint);                
            }
        }
    }


}
