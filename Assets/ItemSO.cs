using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]

public class ItemSO : ScriptableObject
{ 
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public int maxStack = 50;
    public bool isConsumable;
}
