using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject exitInstructions;
    public GameObject solutionInstructions;
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
            solutionInstructions.SetActive(false);
        }
    }

    public void OnClickContinue()
    {
        solutionInstructions.SetActive(true);
    }

    public void OnClickGoBack()
    {
        exitInstructions.SetActive(false);
        solutionInstructions.SetActive(false);
    }

    public void OnClickReady()
    {
        SceneManager.LoadScene("SubmitSolution", LoadSceneMode.Single);
    }
}
