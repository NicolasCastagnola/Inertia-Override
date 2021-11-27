using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolableObject : Prototype
{
    public string ID;
    public abstract void OnReset();
    public abstract void ReturnToPool();
    public static void TurnOn(PoolableObject obj)
    {
        obj.gameObject.SetActive(true);
    }
    public static void TurnOff(PoolableObject obj)
    {
        obj.OnReset();
        obj.gameObject.SetActive(false);
    }
}
