using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Furniture", fileName = "New Furniture")]

public class FurnitureSO : ScriptableObject
{
    [TextArea(3,5)] [SerializeField] public string flavorText;
    [SerializeField] public int id;
    [SerializeField] public ItemSO[] potentialYields;
    [SerializeField] public bool yieldPossible;
}
