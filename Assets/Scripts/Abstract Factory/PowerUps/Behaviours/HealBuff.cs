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

        if (e != null)
        {
            e.TakeHeal(_healAmount); 
            ReturnToPool();
        }
    }
    public override void OnReset()
    {
        Debug.Log("Heal");
    }

    public override void ReturnToPool()
    {
        BuffPoolManager.Instance.healPool.ReturnObject(this);
    }

    public override void TurnOff(Buff type)
    {
        type.gameObject.SetActive(false);
    }

    public override void TurnOn(Buff type)
    {
        type.OnReset();
        type.gameObject.SetActive(true);
    }

    public void Update()
    {
        MoveTowardDirection(Vector3.down * Time.deltaTime * speedTowardsPlayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPickUp(other);
    }
}
