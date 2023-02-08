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
    
    public (string, HashSet<string>) GenerateHint(List<List<string>> solutionList)
    {
        List<string> newEvent = EventGeneration(solutionList);

        int[] categories = GenerateCategories();

        bool naughty = CheckNaughtiness(newEvent, categories);

        while(naughty)
        {
            categories = GenerateCategories();
            naughty = CheckNaughtiness(newEvent, categories);
        }

        Hint newHint = new Hint();

        newHint.multiple = false;

        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];

        newHint.firstAgentSet = new HashSet<string>();
        newHint.firstAgentSet.Add(newEvent[newHint.categoryOne]);
        newHint.firstAgent = newEvent[newHint.categoryOne];

        newHint.secondAgent = newEvent[newHint.categoryTwo];

        List<string> hintSet = GenerateAlternateHints(newHint, solutionList);
        List<string> secondHintSet = FlippedAlternateHints(newHint, solutionList);
        hintSet.AddRange(secondHintSet);
        int randomIndex = Random.Range(0, hintSet.Count);

        string randomHint = hintSet[randomIndex];
        var hashSet = new HashSet<string>(hintSet);

        return (randomHint, hashSet);
    }

    List<string> FlippedAlternateHints(Hint altHint, List<List<string>> solutionList)
    {
        Hint flippedHint = new Hint();
        flippedHint.multiple = false;
        flippedHint.firstAgentSet = new HashSet<string>();
        flippedHint.firstAgentSet.Add(altHint.secondAgent);
        flippedHint.firstAgent = altHint.secondAgent;
        flippedHint.categoryOne = altHint.categoryTwo;
        flippedHint.categoryTwo = altHint.categoryOne;
        flippedHint.secondAgent = altHint.firstAgent;

        List<string> flippedAlternativeSet = GenerateAlternateHints(flippedHint, solutionList);
        return flippedAlternativeSet;
    }

    List<string> GenerateAlternateHints(Hint altHint, List<List<string>> solutionList)
    {
        List<string> alternateHints = new List<string>();
        alternateHints.Add(altHint.ConvertToDialogue());
        List<string> possibleFirstAgents = GeneratePossibleAgents(altHint, solutionList);

        foreach(var agent in possibleFirstAgents)
        {
            Hint multipleHint = new Hint();
            multipleHint.multiple = true;
            multipleHint.firstAgentSet = new HashSet<string>();
            multipleHint.firstAgentSet.Add(altHint.firstAgent);
            multipleHint.firstAgentSet.Add(agent);
            multipleHint.firstAgent = altHint.firstAgent;
            multipleHint.secondAgent = altHint.secondAgent;
            multipleHint.categoryOne = altHint.categoryOne;
            multipleHint.categoryTwo = altHint.categoryTwo;

            alternateHints.Add(multipleHint.ConvertToDialogue());
        }
        return alternateHints;
    }

    List<string> GeneratePossibleAgents(Hint hint, List<List<string>> solutionList)
    {
        List<string> possibleFirstAgents = new List<string>();
        foreach(var randomEvent in solutionList)
        {
            if(!(hint.firstAgentSet.Contains(randomEvent[hint.categoryOne])) && randomEvent[hint.categoryOne] != "naughty")
            {
                possibleFirstAgents.Add(randomEvent[hint.categoryOne]);
            }
        }
        return possibleFirstAgents;
    }
}