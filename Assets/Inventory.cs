using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using System.IO;
using UnityEngine;


[System.Serializable]
public class Inventory : MonoBehaviour
{
    public Dictionary<ItemSO, int> items = new Dictionary<ItemSO, int>();
    public int maxSlots = 50;

    public delegate void OnInventoryChanged();
    public event OnInventoryChanged onInventoryUpdated;
    public string savePath;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        savePath = Path.Combine(Application.persistentDataPath, "Inventory.json");
    }

    public void AddItem(ItemSO newItem, int amount)
    {
        if (items.ContainsKey(newItem))
        {
            items[newItem] += amount;
        }
        else
        {
            if (items.Count > maxSlots)
            {
                Debug.Log("Inventory Full!");
                return;
            }
            items.Add(newItem, amount);
        }
        //Update Inventory UI Here!
        onInventoryUpdated?.Invoke();
    }

    public void RemoveItem(ItemSO itemToRemove, int amount)
    {
        if (items.ContainsKey(itemToRemove))
        {
            items[itemToRemove] -= amount;
            if (items[itemToRemove] < 0)
            {
                items.Remove(itemToRemove);
            }
            //Update Inventory UI Here!
            onInventoryUpdated?.Invoke();
        }
    }

    public bool HasItem(ItemSO item, int amount)
    {
        return items.ContainsKey(item) && items[item] >= amount;
    }

    public void SaveInventory()
    {
        InventoryData data = new InventoryData(items);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Inventory Saved!" + json);
    }

    public void LoadInventory()
    {
        if (File.Exists(savePath))
        {
            Debug.Log("found file at" + savePath);
            string json = File.ReadAllText(savePath);

            InventoryData data = JsonUtility.FromJson<InventoryData>(json);
            items = data.ToDictionary();

            Debug.Log("Inventory after loading = " + items.Count + "items");

            onInventoryUpdated?.Invoke();
        }
        else
        {
            Debug.Log("No save file found");
        }
    }
}
