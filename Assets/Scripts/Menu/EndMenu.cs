using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void ClickStartGame()
    {
        Debug.Log("it works!");
        SceneManager.LoadScene(0);
    }
    public void ClickQuitGame()
    {
        Application.Quit();
    }

}
