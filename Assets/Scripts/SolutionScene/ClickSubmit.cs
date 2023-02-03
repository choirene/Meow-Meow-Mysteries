using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSubmit : MonoBehaviour
{
    public int catId;
    public DropdownSelect activity;
    public DropdownSelect location;
    public List<SolutionDialogueManager> catDMList = new List<SolutionDialogueManager>();

    public AccusationManager aManager;

    List<string> cocoList = new List<string>();
    List<string> basilList = new List<string>();
    List<string> hazelList = new List<string>();
    List<string> jackieList = new List<string>();
    List<string> lukieList = new List<string>();

    List<string> catList = new List<string> { "Coco", "Basil", "Hazel", "Jackie", "Lukie" };
    List<string> activityList = new List<string> {"grooming", "playing", "sleeping", "eating", "naughty"};
    List<string> locationList = new List<string> {"bathroom", "bedroom", "living room", "kitchen", "office"};

    public void Submit()
    {
        List<string> accusation = new List<string>();
        catDMList[catId].accused = true;
        catDMList[catId].EndDialogue();
        accusation.Add(catList[catId]);
        accusation.Add(activityList[activity.selection]);
        accusation.Add(locationList[location.selection]);
        aManager.accusationsMade ++;
        switch(catId)
        {
            case 0:
                cocoList = accusation;
                break;
            case 1:
                basilList = accusation;
                break;
            case 2:
                hazelList = accusation;
                break;
            case 3:
                jackieList = accusation;
                break;
            case 4:
                lukieList = accusation;
                break;            
        }

        if(aManager.accusationsMade == 5)
        {
            List<List<string>> accusationList = new List<List<string>>();
            accusationList.Add(cocoList);
            accusationList.Add(basilList);
            accusationList.Add(hazelList);
            accusationList.Add(jackieList);
            accusationList.Add(lukieList);

            aManager.FinalAccusation(accusationList);
        }

        // submit animation


    }
}
