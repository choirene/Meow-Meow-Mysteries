using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int exit;
    public GameObject exitInstructions;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            exitInstructions.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            exitInstructions.SetActive(false);
        }
    }

    public void OnClickContinue()
    {
        SceneManager.LoadScene(exit, LoadSceneMode.Single);
    }

    public void OnClickGoBack()
    {
        exitInstructions.SetActive(false);
    }
}
