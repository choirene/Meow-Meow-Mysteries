using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintGenerator : MonoBehaviour
{
    // use hash table not dictionary
    Hashtable hintLog = new Hashtable();
    public List<List<string>> solution;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    Hashtable OneToOneHintGenerator()
    {


        return new Hashtable();
    }

//     var cities = new Hashtable(){
// 	{"UK", "London, Manchester, Birmingham"},
// 	{"USA", "Chicago, New York, Washington"},
// 	{"India", "Mumbai, New Delhi, Pune"}
// };

}
