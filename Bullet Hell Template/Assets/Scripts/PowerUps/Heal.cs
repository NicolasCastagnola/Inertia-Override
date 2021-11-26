using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, IConsumable<int, IHealeable<int>>
{
    [SerializeField] private int amount;

    public void OnConsume(int arg, IHealeable<int> type)
    {
        type.OnHeal(arg);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var healable = other.GetComponent<IHealeable<int>>();

        if (healable != null)
        {
            OnConsume(amount, healable);
        }
    }
}
