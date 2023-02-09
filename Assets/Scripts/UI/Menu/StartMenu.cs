using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public List<GameObject> catList;
    public GameObject optionsMenu;
    public Animator transition;

    void Start()
    {
        catList[Random.Range(0,catList.Count)].SetActive(true);
    }

    public void ClickStartGame()
    {
        StartCoroutine(CrossFade(SceneManager.GetActiveScene().buildIndex + 1));
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

    IEnumerator CrossFade(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }


}
