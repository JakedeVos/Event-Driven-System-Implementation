using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
[System.Serializable]

public class InventoryData
{
    public List<string> itemNames = new List<string>();
    public List<int> itemQuantities = new List<int>();

    public InventoryData(Dictionary<ItemSO, int> inventory)
    {
        foreach (var entry in inventory)
        {
            itemNames.Add(entry.Key.itemName);
            itemQuantities.Add(entry.Value);
        }
    }

    public Dictionary<ItemSO, int> ToDictionary()
    {
        //load the item quantity
        Dictionary<ItemSO, int> inventory = new Dictionary<ItemSO, int>();

        foreach (ItemSO item in Resources.LoadAll<ItemSO>("ScriptableObjects"))
        {
            for (int i = 0; i < itemNames.Count; i++)
            {
                Debug.Log(itemNames.Count);
                if (item.itemName == itemNames[i])
                {
                    if (!inventory.ContainsKey(item))
                    {
                        inventory[item] = itemQuantities[i];
                    }
                    else
                    {
                        inventory[item] += itemQuantities[i];
                    }
                }

            }
        }
        Debug.Log("restored items from save " + inventory.Count);
        return inventory;
    }
}

