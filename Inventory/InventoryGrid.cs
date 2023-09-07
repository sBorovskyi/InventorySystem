using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;

    [SerializeField] private int height;
    [SerializeField] private int width;

    private void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Instantiate(slotPrefab, transform.position + new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }
}
