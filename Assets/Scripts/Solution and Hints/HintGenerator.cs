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

        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];

        newHint.firstAgentList = new List<string>();
        newHint.firstAgentList.Add(newEvent[newHint.categoryOne]);

        newHint.secondAgent = newEvent[newHint.categoryTwo];

        List<string> hintSet = GenerateAlternateHints(newHint, solutionList);
        List<string> secondHintSet = FlippedAlternateHints(newHint, solutionList);
        hintSet.AddRange(secondHintSet);

        int randomIndex = Random.Range(0, 5);

        string randomHint = hintSet[randomIndex];
        var hashSet = new HashSet<string>(hintSet);

        return (randomHint, hashSet);
    }

    List<string> FlippedAlternateHints(Hint altHint, List<List<string>> solutionList)
    {
        Hint flippedHint = new Hint();
        flippedHint.firstAgentList = new List<string>();
        flippedHint.firstAgentList.Add(altHint.secondAgent);
        flippedHint.categoryOne = altHint.categoryTwo;
        flippedHint.categoryTwo = altHint.categoryOne;
        flippedHint.secondAgent = altHint.firstAgentList[0];

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
            multipleHint.firstAgentList = new List<string>();
            multipleHint.firstAgentList.Add(altHint.firstAgentList[0]);
            multipleHint.firstAgentList.Add(agent);
            multipleHint.secondAgent = altHint.secondAgent;
            multipleHint.categoryOne = altHint.categoryOne;
            multipleHint.categoryTwo = altHint.categoryTwo;

            alternateHints.Add(multipleHint.ConvertToDialogue());

            Hint newHint = new Hint();
            newHint.firstAgentList = new List<string>();
            newHint.firstAgentList.Add(agent);
            newHint.firstAgentList.Add(altHint.firstAgentList[0]);
            newHint.secondAgent = altHint.secondAgent;
            newHint.categoryOne = altHint.categoryOne;
            newHint.categoryTwo = altHint.categoryTwo;

            alternateHints.Add(newHint.ConvertToDialogue());

        }
        return alternateHints;
    }

    List<string> GeneratePossibleAgents(Hint hint, List<List<string>> solutionList)
    {
        List<string> possibleFirstAgents = new List<string>();
        foreach(var randomEvent in solutionList)
        {
            if(randomEvent[hint.categoryOne] != hint.firstAgentList[0] && randomEvent[hint.categoryOne] != "naughty")
            {
                possibleFirstAgents.Add(randomEvent[hint.categoryOne]);
            }
        }
        return possibleFirstAgents;
    }
}