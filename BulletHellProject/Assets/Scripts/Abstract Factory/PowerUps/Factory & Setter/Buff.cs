using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour, IPickupable<Collider>
{
    [SerializeField] private string _id;
    [SerializeField] private float speedTowardsPlayer;
    public string ID => _id;
    public abstract IEnumerator Feedback();
    public abstract void OnPickUp(Collider collider);
    public abstract void OnReturnToPool();
    public virtual void MoveTowardDirection(Vector3 targetDirection)
    {
        transform.position += new Vector3(targetDirection.x, targetDirection.y, targetDirection.z);
    }
}
