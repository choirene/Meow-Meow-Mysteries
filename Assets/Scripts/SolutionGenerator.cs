using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionGenerator : MonoBehaviour
{
    public List<List<string>> solution = new List<List<string>>();
    List<string> catList = new List<string> { "Coco", "Basil", "Hazel", "Jackie", "Lukie" };
    List<string> locationList = new List<string> {"Bathroom", "Bedroom", "Living Room", "Kitchen", "Office"};
    List<string> activityList = new List<string> {"Grooming", "Playing", "Sleeping", "Eating", "Naughty"};

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            List<string> randomEvent = new List<string>();

            int randomCat = Random.Range(0,5);
            int randomLocation = Random.Range(0,5);
            int randomActivity = Random.Range(0,5);

            string cat = catList[randomCat];
            string location = locationList[randomLocation];
            string activity = activityList[randomActivity];

            randomEvent.Add(cat);
            randomEvent.Add(location);
            randomEvent.Add(activity);

            solution.Add(randomEvent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
