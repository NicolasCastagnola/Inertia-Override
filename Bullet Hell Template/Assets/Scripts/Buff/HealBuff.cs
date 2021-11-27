using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBuff : Buff
{
    [SerializeField] private int _healAmount;
    public override IEnumerator Feedback()
    {
        throw new System.NotImplementedException();
    }

    public override void OnPickUp(Collider other)
    {
        var e = other.GetComponent<IEntity<AlliedEntity>>();

        if (e != null) e.TakeHeal(_healAmount);
    }
}
