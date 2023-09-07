using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatComponent : MonoBehaviour, IItemAction
{
    [SerializeField] private int foodAmmount;
    public string Name { get; set; }


    private void Start()
    {
        Name = "Eat";
    }

    public void Eat()
    {
        StatsSystem.Instance.AddFood(foodAmmount);
        Destroy(gameObject);
    }

    public void UseAction()
    {
        Eat();
    }
}
