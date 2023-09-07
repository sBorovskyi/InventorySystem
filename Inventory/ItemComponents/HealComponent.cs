using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealComponent : MonoBehaviour, IItemAction
{
    [SerializeField] private int healtToAdd;

    public string Name { get ; set ; }

    private void Start()
    {
        Name = "Use";
    }

    public void Heal()
    {
        StatsSystem.Instance.AddHealth(healtToAdd);
        Destroy(gameObject);
    }

    public void UseAction()
    {
        Heal();
    }
}
