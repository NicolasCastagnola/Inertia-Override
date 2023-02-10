using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour, IPickupable<Collider>, IPoolable<Buff>
{
    [SerializeField] private string _id;
    [SerializeField] protected float speedTowardsPlayer;
    public string ID => _id;
    public abstract IEnumerator Feedback();
    public abstract void OnPickUp(Collider collider);
    public virtual void MoveTowardDirection(Vector3 targetDirection)
    {
        transform.position += new Vector3(targetDirection.x, targetDirection.y, targetDirection.z);
    }
    public abstract void TurnOn(Buff type);
    public abstract void TurnOff(Buff type);
    public abstract void ReturnToPool();
    public abstract void OnReset();
}
