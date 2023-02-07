using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyPanel : MonoBehaviour
{
    public GameObject keyPanel;
    public GameObject instructions;
    public List<GameObject> keys;
    int currentKey;
    bool activeSelection;
    bool keyPanelActive;
    [SerializeField] private Canvas canvas;

    private void Start() 
    {
        currentKey = -1;
        keyPanelActive = false;
    }
    public void ToggleKey()
    {
        keyPanelActive = !keyPanelActive;
        keyPanel.SetActive(keyPanelActive);
    }

    public void ClickCategoryKey(int newKey)
    {
        if(currentKey == newKey)
        {
            instructions.SetActive(true);
            keys[currentKey].SetActive(false);
            currentKey = -1;
            activeSelection = false;
        }
        else
        {
            if(activeSelection)
            {
                keys[currentKey].SetActive(false);
            }
            instructions.SetActive(false);
            currentKey = newKey;
            keys[currentKey].SetActive(true);
            activeSelection = true;
        }
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}
