using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public List<GameObject> allRemind = new List<GameObject>();

    public void Rewind()
    {
        foreach (var item in allRemind)
        {
            if (item.GetComponent<IRewindable>() != null)
            {
                item.GetComponent<IRewindable>().Action();
            }
            else
            {
                Debug.LogWarning($"Item: {item.name} does not contain the IRewindable interface");
            }
        }
    }

    public void Memento()
    {
        foreach (var item in allRemind)
        {
            if (item.GetComponent<IRewindable>() != null)
            {
                item.GetComponent<IRewindable>().SaveMementoParamerters();
            }
            else
            {
                Debug.LogWarning($"Item: {item.name} does not contain the IRewindable interface");
            }
        }
    }
}