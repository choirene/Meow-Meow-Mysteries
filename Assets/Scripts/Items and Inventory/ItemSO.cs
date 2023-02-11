using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public int id;
    public int quantity;
    [SerializeField] public int pickyFactor;
    [SerializeField] public Sprite icon;
}
