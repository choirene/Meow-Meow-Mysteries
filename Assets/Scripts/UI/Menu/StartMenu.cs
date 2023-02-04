using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public List<GameObject> catList;
    public GameObject optionsMenu;

    void Start()
    {
        catList[Random.Range(0,catList.Count)].SetActive(true);
    }

    public void ClickStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
    public void ClickOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }
    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }
    public void ClickQuitGame()
    {
        Application.Quit();
    }

}
