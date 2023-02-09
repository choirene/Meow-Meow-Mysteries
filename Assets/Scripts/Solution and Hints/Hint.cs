using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint 
{
    // public bool multiple;
    public List<string> firstAgentList;
    public int categoryOne;
    public string secondAgent;
    public int categoryTwo;

    public string ConvertToDialogue()
    {
        // Basil was playing in the bathroom.
        string cat = string.Empty;
        string activity = string.Empty;
        string location = string.Empty;

        // Who
        if(categoryOne == 0)
        {  
            cat = firstAgentList[0] + " ";
            if(firstAgentList.Count > 1)
            {
                cat = cat + "or " + firstAgentList[1] + " ";
            }
        }
        else if(categoryTwo == 0)
        {
            cat = secondAgent + " ";
        }
        else
        {
            cat = "Someone ";
        }
        cat = cat + "was ";

        // What
        if(categoryOne == 1)
        {  
            activity = firstAgentList[0] + " ";
            if(firstAgentList.Count > 1)
            {
                activity = activity + "or " + firstAgentList[1] + " ";
            }
        }
        else if(categoryTwo == 1)
        {
            activity = secondAgent + " ";
        }

        // Where
        if(categoryOne == 2)
        {
            location = "in the " + firstAgentList[0];
            if(firstAgentList.Count > 1)
            {
                location = location + " or " + firstAgentList[1];
            }
        }
        else if(categoryTwo == 2)
        {
            location = "in the " + secondAgent;
        }

        string dialogue = cat + activity + location;

        return dialogue;
    }
}