using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] int type;
    [SerializeField] public int pickyFactor;
    [SerializeField] public Sprite icon;
}
