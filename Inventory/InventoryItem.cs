using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    
    private IItemAction[] itemActions;

    void Start()
    {
        itemActions = GetComponents<IItemAction>();
    }

    public int GetComponentCount()
    {
        return itemActions.Length;
    }

    public IItemAction[] GetItemActionList()
    {
        return itemActions;
    }
}


public interface IItemAction
{
    public string Name { get; set; }

    public void UseAction();
}
