using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform inventoryPanel;
    public GameObject inventorySlotPrefab;

    private List<GameObject> slots = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //dont destroy the game object when the game first loads
        DontDestroyOnLoad(this.gameObject);
        inventory = FindFirstObjectByType<Inventory>();
        inventory.onInventoryUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        inventory.onInventoryUpdated -= UpdateUI;
    }

    private void UpdateUI()
    {
        //clear old slots out
        foreach (var slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();
        //create new slots from dictionary
        foreach (KeyValuePair<ItemSO, int> entry in inventory.items)
        {
            GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryPanel);
            //populate UI info here
            newSlot.GetComponent<InventorySlotUI>().nameText.text = entry.Key.itemName;
            newSlot.GetComponent<InventorySlotUI>().descriptionText.text = entry.Key.itemDescription;
            newSlot.GetComponent<InventorySlotUI>().icon.sprite = entry.Key.icon;
            slots.Add(newSlot);
        }
    }


}

