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
    public bool atCapacity;
    public int naughtyCatId;
    List<string> naughtyList = new List<string>();
    public static SolutionAndHintData instance;

    void Awake() 
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

        solutionList = solution.generateSolution();
        int i = 0;
        foreach(var solution in solutionList)
        {
            if(solution[1] == "naughty")
            {
                naughtyCatId = i;
                naughtyList = solution;
                break;
            }
            i++;
        }
    }
    void Start()
    {
        InitialHintGeneration();
    }

    public static SolutionAndHintData GetInstance()
    {
        return instance;
    }
    void InitialHintGeneration()
    {
        while(convertedHintList.Count < 3)
        {
            Hint newHint = hintGenerator.TwoToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateHint(convertedHint);
            if(flag)
            {
                convertedHintList.Add(convertedHint);
            }
        }
        while(convertedHintList.Count < 5)
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

    public void GenerateRandomHint(string catName)
    {
        int type = Random.Range(0,5);
        if(convertedHintList.Count > 10)
        {
            type = 0;
        }
        if(type == 0)
        {
            Hint newHint = hintGenerator.OneToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateGeneratedHint(convertedHint, newHint, catName);
            while(!flag)
            {
                newHint = hintGenerator.OneToOneHintGenerator(solutionList);
                convertedHint = newHint.ConvertToDialogue();
                flag = ValidateGeneratedHint(convertedHint, newHint, catName);
            }
            convertedHintList.Add(convertedHint);
        }
        else
        {
            Hint newHint = hintGenerator.TwoToOneHintGenerator(solutionList);
            string convertedHint = newHint.ConvertToDialogue();
            bool flag = ValidateGeneratedHint(convertedHint, newHint, catName);
            while(!flag)
            {
                newHint = hintGenerator.TwoToOneHintGenerator(solutionList);
                convertedHint = newHint.ConvertToDialogue();
                flag = ValidateGeneratedHint(convertedHint, newHint, catName);
            }
            convertedHintList.Add(convertedHint);
        }
        if(convertedHintList.Count == 25)
        {
            atCapacity = true;
        }
        displayHints.GetComponent<DisplayHints>().UpdateHints();
    }

    public bool ValidateGeneratedHint(string convertedHint, Hint hint, string catName)
    {
        if(convertedHintList.Contains(convertedHint))
        {
            return false;
        }

        if(hint.categoryOne == 0)
        {
            foreach(var cat in hint.firstAgentSet)
            {
                if(cat == catName)
                {
                    return false;
                }
            }
        }
        else if(hint.categoryTwo == 0)
        {
            if(hint.secondAgent == catName)
            {
                return false;
            }
        }

        return true;
    }

    public bool ValidateHint(string convertedHint)
    {
        if(convertedHintList.Contains(convertedHint))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void NaughtyAction()
    {
    }
}