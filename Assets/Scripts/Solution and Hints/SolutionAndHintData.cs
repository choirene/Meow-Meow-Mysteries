using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionAndHintData : MonoBehaviour
{
    SolutionGenerator solution = new SolutionGenerator();
    HintGenerator hintGenerator = new HintGenerator();
    public List<string> convertedHintList = new List<string>();
    List<List<string>> trueHints = new List<List<string>>();
    List<List<string>> extraHints = new List<List<string>>();
    public List<List<string>> solutionList = new List<List<string>>();
    public bool atCapacity;
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
        GenerateTrueHints();
    }
    public static SolutionAndHintData GetInstance()
    {
        return instance;
    }

    void GenerateTrueHints()
    {
        foreach(var combo in solutionList)
        {
            if(combo[1] == "naughty")
            {
                List<string> naughtyCopy = new List<string>();
                naughtyCopy.Add(combo[0]);
                naughtyCopy.Add(null);
                naughtyCopy.Add(combo[2]);
                trueHints.Add(naughtyCopy);
            }
            else
            {
                List<List<string>> eventCopies = new List<List<string>>();
                for(int i = 0; i < 3; i++)
                {
                    List<string> eventCopy = new List<string>();
                    for(int j = 0; j < 3; j++)
                    {
                        eventCopy.Add(combo[j]);
                    }
                    eventCopies.Add(eventCopy);
                }
                for(int i = 0; i < eventCopies.Count; i++)
                {
                    eventCopies[i][i] = null;
                }
                trueHints.AddRange(eventCopies);
            }
        }
    }

    public void GenerateRandomHint(string catName)
    {
        if(trueHints.Count > 0)
        {
            int randomIndex = Random.Range(0, trueHints.Count);
            string newHint = hintGenerator.CreateNewHint(trueHints[randomIndex], solutionList);
            while(newHint.Contains(catName))
            {
                randomIndex = Random.Range(0, trueHints.Count);
                newHint = hintGenerator.CreateNewHint(trueHints[randomIndex], solutionList);
            }
            if(newHint.Contains("or"))
            {
                extraHints.Add(trueHints[randomIndex]);
            }
            trueHints.RemoveAt(randomIndex);

            convertedHintList.Add(newHint);
        }
        else
        {
            int randomIndex = Random.Range(0, extraHints.Count);
            string newHint = hintGenerator.CreateNewHint(extraHints[randomIndex], solutionList);
            while(newHint.Contains(catName) || convertedHintList.Contains(newHint))
            {
                randomIndex = Random.Range(0, extraHints.Count);
                newHint = hintGenerator.CreateNewHint(extraHints[randomIndex], solutionList);
            }
            convertedHintList.Add(newHint);
        }
        if(convertedHintList.Count >= 30)
        {
            atCapacity = true;
        }
    }
}