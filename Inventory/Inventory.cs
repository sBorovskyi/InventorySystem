using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        inventoryItems.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        inventoryItems.Remove(item);
    }
}
