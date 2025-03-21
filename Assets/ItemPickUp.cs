using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public ItemSO item;
    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        //Player collides with item and it gets destroyed
        if (other.tag == "Player")
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory)
            {
                inventory.AddItem(item, amount);
                Destroy(gameObject);
            }
        }


    }
}

