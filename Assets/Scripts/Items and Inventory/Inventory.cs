using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] inventorySlots;
    [SerializeField] TMP_Text[] inventoryQuantities;
    [SerializeField] GameObject[] bribeSlots;
    [SerializeField] TMP_Text[] bribeQuantities;
    [SerializeField] ItemSO[] itemData;
    [SerializeField] FurnitureSO[] furnitureData;
    public static Inventory instance;
    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

        for(int i = 0; i < itemData.Length; i++)
        {
            itemData[i].quantity = 0;
            inventorySlots[i].SetActive(false);
            bribeSlots[i].SetActive(false);
        }
        foreach(var furniture in furnitureData)
        {
            if(furniture.potentialYields.Length > 0)
            {
                furniture.yieldPossible = true;
            }
        }
    }
    public static Inventory GetInstance()
    {
        return instance;
    }

    public void AddItem(int itemId)
    {
        if(itemData[itemId].quantity == 0)
        {
            inventorySlots[itemId].SetActive(true);
            bribeSlots[itemId].SetActive(true);
        }
        itemData[itemId].quantity ++;
        UpdateUI();
    }
    public void RemoveItem(int itemId)
    {
        itemData[itemId].quantity --;
        if(itemData[itemId].quantity == 0)
        {
            inventorySlots[itemId].SetActive(false);
            bribeSlots[itemId].SetActive(false);
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        for(int i = 0; i < inventorySlots.Length; i ++)
        {
            inventoryQuantities[i].text = itemData[i].quantity.ToString();
            bribeQuantities[i].text = itemData[i].quantity.ToString();
        }
    }
}
