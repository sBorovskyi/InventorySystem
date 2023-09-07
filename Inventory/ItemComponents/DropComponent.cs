using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropComponent : MonoBehaviour, IItemAction
{

    public string Name { get; set; }

    private void Start()
    {
        Name = "Drop";
    }

    public void Drop()
    {
        Destroy(gameObject);
    }

    public void UseAction()
    {
        Drop();
    }
}
