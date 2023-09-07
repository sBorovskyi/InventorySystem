using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject contextMenuVisual;
    [SerializeField] private Transform grid;

    [SerializeField] private Vector3 offsetVector;

    private void Start()
    {
        contextMenuVisual.SetActive(false);
    }

    private void Update()
    {
        Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cursorRay, out RaycastHit hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (hit.transform.TryGetComponent(out InventoryItem inventoryItem))
                {
                    DestroyAllButtons();
                    SpawnButtons(inventoryItem);
                    OpenMenu();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Invoke("CloseMenu", 0.1f);
        }


    }

    private void CloseMenu()
    {
        contextMenuVisual.SetActive(false);
    }

    public void OpenMenu()
    {
        contextMenuVisual.SetActive(true);
        contextMenuVisual.transform.position = Input.mousePosition + offsetVector;
    }

    private void DestroyAllButtons()
    {
        foreach (Transform item in grid.transform)
        {
            Destroy(item.gameObject);
        }
    }

    private void SpawnButtons(InventoryItem inventoryItem)
    {
        for (int i = 0; i < inventoryItem.GetComponentCount() ; i++)
        {
            GameObject spawnedButton = Instantiate(button, grid);
            spawnedButton.GetComponentInChildren<TextMeshProUGUI>().text = inventoryItem.GetItemActionList()[i].Name;
            spawnedButton.GetComponent<Button>().onClick.AddListener(inventoryItem.GetItemActionList()[i].UseAction);
        }
    }

}
