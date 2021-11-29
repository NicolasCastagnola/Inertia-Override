using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Buff Configuration")]
public class BuffSetter : ScriptableObject
{
    [SerializeField] private Buff[] _objects;
    private Dictionary<string, Buff> _idToObject;

    private void Awake()
    {
        _idToObject = new Dictionary<string, Buff>();

        foreach (var obj in _objects)
        {
            _idToObject.Add(obj.ID, obj);
        }
    }

    public Buff GetBuffWithId(string id)
    {
        if (!_idToObject.TryGetValue(id, out var buff))
        {
            throw new Exception($"object with id {id} cannot be found in dictionary, must be misspell or does not exist.");
        }

        return buff;
    }
}
