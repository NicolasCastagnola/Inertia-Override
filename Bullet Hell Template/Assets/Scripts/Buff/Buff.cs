using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour, IPickupable<Collider>
{
    [SerializeField] private string _id;
    public string ID => _id;
    public abstract IEnumerator Feedback();
    public abstract void OnPickUp(Collider collider);
}
