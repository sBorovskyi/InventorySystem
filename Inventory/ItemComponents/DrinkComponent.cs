using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkComponent : MonoBehaviour, IItemAction
{
    [SerializeField] private int waterAmmount;

    public string Name { get; set; }

    private void Start()
    {
        Name = "Drink";
    }

    public void Drink()
    {
        StatsSystem.Instance.AddWater(waterAmmount);
        Destroy(gameObject);
    }

    public void UseAction()
    {
        Drink();
    }
}
