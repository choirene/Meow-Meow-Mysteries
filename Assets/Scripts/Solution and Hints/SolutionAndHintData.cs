using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionAndHintData : MonoBehaviour
{
    SolutionGenerator solution = new SolutionGenerator();
    HintGenerator hintGenerator = new HintGenerator();
    public List<string> convertedHintList = new List<string>();
    private HashSet<string> hiddenHintSet = new HashSet<string>();
    public List<List<string>> solutionList = new List<List<string>>();
    public GameObject displayHints;
    public bool atCapacity;
    public static SolutionAndHintData instance;
    private int duplicatesFound;
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
        while(convertedHintList.Count < 5)
        {
            (string newHint, HashSet<string> potentialHints) = hintGenerator.GenerateHint(solutionList);
            if(ValidateHint(newHint))
            {
                convertedHintList.Add(newHint);
                hiddenHintSet.UnionWith(potentialHints);
            }
        }
    }

    public void GenerateRandomHint(string catName)
    {
        (string newHint, HashSet<string> potentialHints) = hintGenerator.GenerateHint(solutionList);
        bool flag = ValidateGeneratedHint(newHint, catName);

        duplicatesFound = 0;
        while(!flag)
        {
            (newHint, potentialHints) = hintGenerator.GenerateHint(solutionList);
            flag = ValidateGeneratedHint(newHint, catName);
        }

        convertedHintList.Add(newHint);
        hiddenHintSet.UnionWith(potentialHints);
        if(convertedHintList.Count >= 25)
        {
            atCapacity = true;
        }
        displayHints.GetComponent<DisplayHints>().UpdateHints();
        Debug.Log(convertedHintList.Count);
        Debug.Log(duplicatesFound);
    }

    public bool ValidateGeneratedHint(string hint, string catName)
    {
        if(hint.Contains(catName) || convertedHintList.Contains(hint))
        {
            return false;
        }
        if(duplicatesFound > 40)
        {
            return true;
        }
        if(hiddenHintSet.Contains(hint))
        {
            duplicatesFound ++;
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ValidateHint(string newHint)
    {
        if(hiddenHintSet.Contains(newHint))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}