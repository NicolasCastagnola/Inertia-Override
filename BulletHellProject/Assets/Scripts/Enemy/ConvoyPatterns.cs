using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Convoy Patterns Container")]
public class ConvoyPatterns : ScriptableObject
{
    [SerializeField] private ConvoyFlyweight[] _patterns;

    private Dictionary<string, ConvoyFlyweight> _idToObject;

    private void Awake()
    {
        _idToObject = new Dictionary<string, ConvoyFlyweight>();

        foreach (var obj in _patterns)
        {
            _idToObject.Add(obj.PatternID, obj);
        }
    }

    public ConvoyFlyweight GetBuffWithId(string id)
    {
        if (!_idToObject.TryGetValue(id, out var buff))
        {
            throw new Exception($"object with id {id} cannot be found in dictionary, must be misspell or does not exist.");
        }

        return buff;
    }
}
