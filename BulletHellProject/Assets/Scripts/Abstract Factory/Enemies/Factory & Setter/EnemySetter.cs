using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemies Configuration")]
public class EnemySetter : ScriptableObject
{
    [SerializeField] private Enemy[] _objects;
    private Dictionary<string, Enemy> _idToObject;

    private void Awake()
    {
        _idToObject = new Dictionary<string, Enemy>();

        foreach (var obj in _objects)
        {
            _idToObject.Add(obj.ID, obj);
        }
    }

    public Enemy GetBuffWithId(string id)
    {
        if (!_idToObject.TryGetValue(id, out var buff))
        {
            throw new Exception($"object with id {id} cannot be found in dictionary, must be misspell or does not exist.");
        }

        return buff;
    }
}
