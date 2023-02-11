using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "WinScene" || SceneManager.GetActiveScene().name == "LoseScene")
        {
            Destroy(GameObject.Find("MenuCanvas"));
            Destroy(GameObject.Find("SolutionAndHintData"));
            Destroy(GameObject.Find("Inventory"));
        }
    }
    void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
