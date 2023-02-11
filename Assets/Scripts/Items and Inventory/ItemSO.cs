using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] int type;
    [SerializeField] int pickyFactor;
    [SerializeField] Sprite icon;
}
