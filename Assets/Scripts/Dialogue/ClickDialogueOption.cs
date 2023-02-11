using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDialogueOption : MonoBehaviour
{
    public int catId;
    public List<DialogueManager> catList = new List<DialogueManager>();
    [SerializeField] GameObject[] rulesList;

    public void OnClickBeg()
    {
        catList[catId].ClickBeg();
    }

    public void OnClickPlay()
    {
        catList[catId].ClickPlay();
    }

    public void OnClickBribe()
    {
        catList[catId].ClickBribe();
    }
    public void OnClickQuit()
    {
        catList[catId].ClickQuit();
    }

    public void OnClickStart()
    {
        catList[catId].ClickStart();
    }

    public void OnClickRules(bool active)
    {
        rulesList[catId].SetActive(active);
    }

    public void OnQuitGame()
    {
        catList[catId].QuitGame();
    }

    public void OnPickItem(ItemSO bribeItem)
    {
        catList[catId].PickItem(bribeItem);
    }

    public void OnConfirmItem(bool response)
    {
        catList[catId].ConfirmItem(response);
    }

}
