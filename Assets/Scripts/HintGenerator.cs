using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintGenerator : MonoBehaviour
{
    // // use hash table not dictionary
    // Hashtable hintLog = new Hashtable();
    public List<Hint> hintList;
    public SolutionGenerator solution;
    public List<List<string>> solutionList = new List<List<string>>();
    
    void Start()
    {
        solutionList = solution.solutionList;
        Hint oneHint = OneToOneHintGenerator();
        string convertedHint = oneHint.ConvertToDialogue();
        Debug.Log(convertedHint);
        Hint twoHint = TwoToOneHintGenerator();
        string convertedTwoHint = twoHint.ConvertToDialogue();
        Debug.Log(convertedTwoHint);
    }

    void Update()
    {
        
    }

    int[] GenerateCategories()
    {
        int randomCategory = Random.Range(0,3);
        int randomCategoryTwo = Random.Range(0,3);
        while(randomCategory == randomCategoryTwo)
        {
            randomCategoryTwo = Random.Range(0,3);
        }
        return new [] { randomCategory, randomCategoryTwo };    
    }

    List<string> EventGeneration()
    {
        int randomInt = Random.Range(0,5);
        List<string> newEvent = solutionList[randomInt];
        return newEvent;
    }

    bool CheckNaughtiness(List<string> currentEvent, int[] categories)
    {
        foreach(var category in categories)
        {
            if(currentEvent[category] == "naughty")
            {
                return true;
            }
        }
        return false;
    }

    Hint OneToOneHintGenerator()
    {
        Hint newHint = new Hint();

        newHint.multiple = false;

        List<string> newEvent = EventGeneration();

        int[] categories = GenerateCategories();

        bool naughty = CheckNaughtiness(newEvent, categories);

        while(naughty)
        {
            categories = GenerateCategories();
            naughty = CheckNaughtiness(newEvent, categories);
        }

        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];

        newHint.firstAgentList = new List<string>();
        newHint.firstAgentList.Add(newEvent[newHint.categoryOne]);

        newHint.secondAgent = newEvent[newHint.categoryTwo];

        return newHint;
    }
    Hint TwoToOneHintGenerator()
    {
        Hint newHint = new Hint();

        newHint.multiple = true;

        List<string> newEvent = EventGeneration();

        int[] categories = GenerateCategories();

        bool naughty = CheckNaughtiness(newEvent, categories);

        while(naughty)
        {
            categories = GenerateCategories();
            naughty = CheckNaughtiness(newEvent, categories);
        }

        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];

        newHint.firstAgentList = new List<string>();
        newHint.firstAgentList.Add(newEvent[newHint.categoryOne]);

        List<string> possibleFirstAgents = new List<string>();
        foreach(var i in solutionList)
        {
            if(i[newHint.categoryOne] != newHint.firstAgentList[0] && i[newHint.categoryOne] != "naughty")
            {
                possibleFirstAgents.Add(i[newHint.categoryOne]);
            }
        }
        int randomIndex = Random.Range(0,4);
        newHint.firstAgentList.Add(possibleFirstAgents[randomIndex]);

        newHint.secondAgent = newEvent[newHint.categoryTwo];

        return newHint;
    }
}
