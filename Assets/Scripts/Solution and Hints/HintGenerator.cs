using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintGenerator
{
    public string CreateNewHint(List<string> baseHint, List<List<string>> solutionList)
    {
        Hint newHint = new Hint();
        List<int> categories = new List<int>();
        List<string> agents = new List<string>();
        for(int i = 0; i < 3; i++)
        {
            if(baseHint[i] != null)
            {
                categories.Add(i);
                agents.Add(baseHint[i]);
            }
        }
        newHint.categoryOne = categories[0];
        newHint.categoryTwo = categories[1];
        newHint.firstAgentList = new List<string>();
        newHint.firstAgentList.Add(agents[0]);
        newHint.secondAgent = agents[1];

        List<string> hintSet = GenerateAlternateHints(newHint, solutionList);
        int randomIndex = Random.Range(0, 5);

        string randomHint = hintSet[randomIndex];

        return randomHint;
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