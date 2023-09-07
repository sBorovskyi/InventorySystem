using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem : MonoBehaviour
{

    [SerializeField] private LayerMask movingLayer;
    [SerializeField] private LayerMask inventoryLayer;

    private GameObject selectedItem;
    private Vector3 lastItemPosition;
   
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out RaycastHit itemHit))
            {
                if (itemHit.collider.TryGetComponent(out InventoryItem inventoryItem))
                {
                    lastItemPosition = inventoryItem.transform.position;
                    selectedItem = inventoryItem.gameObject;
                    RemoveItemFromInventory();
                }
            }
        }

        if (selectedItem != null)
        {
            if (Physics.Raycast(ray, out RaycastHit inventoryHit, 1000, movingLayer))
            {
                selectedItem.transform.position = inventoryHit.transform.position;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && selectedItem != null)
        {
            if (!TryToPlaceItem())
            {
                selectedItem.transform.position = lastItemPosition;
            }
            else
            {
                AddItemToInventory();
            }
        
            selectedItem = null;
        }
    }

    private void RemoveItemFromInventory()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, inventoryLayer))
        {
            if (hit.transform.gameObject.TryGetComponent(out Inventory inventory))
            {
                inventory.RemoveItem(selectedItem.GetComponent<InventoryItem>());
            }
        }
    }


    private void AddItemToInventory()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, inventoryLayer))
        {
            if (hit.transform.gameObject.TryGetComponent(out Inventory inventory))
            {
                inventory.AddItem(selectedItem.GetComponent<InventoryItem>());
            }
        }
    }

    private bool TryToPlaceItem()
    {
        Collider[] collidersInZone = Physics.OverlapBox(selectedItem.transform.position + selectedItem.GetComponent<BoxCollider>().center,
                                                        selectedItem.GetComponent<BoxCollider>().size / 2);

        List<InventoryItem> inventoryItemsInZone = new List<InventoryItem>();

        foreach (Collider collider in collidersInZone)
        {
            if (collider.TryGetComponent(out InventoryItem inventoryItem))
            {
                inventoryItemsInZone.Add(inventoryItem);
            }
        }

        if (inventoryItemsInZone.Count > 1)
        {
            return false;
        }
        return true;
        
    }
}
