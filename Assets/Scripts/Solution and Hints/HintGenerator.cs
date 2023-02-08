using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintGenerator
{
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

    List<string> EventGeneration(List<List<string>> solutionList)
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
    
    public Hint OneToOneHintGenerator(List<List<string>> solutionList)
    {
        Hint newHint = new Hint();

        newHint.multiple = false;

        List<string> newEvent = EventGeneration(solutionList);

        int[] categories = GenerateCategories();

        bool naughty = CheckNaughtiness(newEvent, categories);

        while(naughty)
        {
            categories = GenerateCategories();
            naughty = CheckNaughtiness(newEvent, categories);
        }

        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];

        newHint.firstAgentSet = new HashSet<string>();
        newHint.firstAgentSet.Add(newEvent[newHint.categoryOne]);

        newHint.secondAgent = newEvent[newHint.categoryTwo];

        return newHint;
    }
    public Hint TwoToOneHintGenerator(List<List<string>> solutionList)
    {
        Hint newHint = new Hint();

        newHint.multiple = true;

        List<string> newEvent = EventGeneration(solutionList);

        int[] categories = GenerateCategories();

        bool naughty = CheckNaughtiness(newEvent, categories);

        while(naughty)
        {
            categories = GenerateCategories();
            naughty = CheckNaughtiness(newEvent, categories);
        }

        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];

        newHint.firstAgentSet = new HashSet<string>();
        newHint.firstAgentSet.Add(newEvent[newHint.categoryOne]);

        List<string> possibleFirstAgents = new List<string>();
        foreach(var i in solutionList)
        {
            if(!(newHint.firstAgentSet.Contains(i[newHint.categoryOne])) && i[newHint.categoryOne] != "naughty")
            {
                possibleFirstAgents.Add(i[newHint.categoryOne]);
            }
        }
        int randomIndex = Random.Range(0,possibleFirstAgents.Count);
        newHint.firstAgentSet.Add(possibleFirstAgents[randomIndex]);

        newHint.secondAgent = newEvent[newHint.categoryTwo];

        return newHint;
    }
}