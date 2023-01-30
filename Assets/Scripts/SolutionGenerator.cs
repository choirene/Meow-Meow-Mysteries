using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionGenerator : MonoBehaviour
{
    public List<List<string>> solutionList = new List<List<string>>();
    List<string> catList = new List<string> { "Coco", "Basil", "Hazel", "Jackie", "Lukie" };
    List<string> activityList = new List<string> {"grooming", "playing", "sleeping", "eating", "naughty"};
    List<string> locationList = new List<string> {"bathroom", "bedroom", "living room", "kitchen", "office"};

    void Awake()
    {
        for(int i = 0; i < 5; i++)
        {
            List<string> randomEvent = new List<string>();

            int upperRange = 5 - solutionList.Count;

            int randomCat = Random.Range(0,upperRange);
            int randomActivity = Random.Range(0,upperRange);
            int randomLocation = Random.Range(0,upperRange);

            string cat = catList[randomCat];
            string activity = activityList[randomActivity];
            string location = locationList[randomLocation];

            randomEvent.Add(cat);
            randomEvent.Add(activity);
            randomEvent.Add(location);

            catList.RemoveAt(randomCat);
            activityList.RemoveAt(randomActivity);
            locationList.RemoveAt(randomLocation);

            solutionList.Add(randomEvent);
        }
    }

    void Start() {
    }

    public List<List<string>> giveSolution()
    {
        return solutionList;
    }

}