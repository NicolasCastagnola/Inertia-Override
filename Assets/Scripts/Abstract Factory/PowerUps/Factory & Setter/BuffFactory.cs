using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class BuffFactory
{
    [SerializeField] private BuffSetter _buffSetter;

    public BuffFactory(BuffSetter buffSetter)
    {
        _buffSetter = buffSetter;
    }

    public Buff SetBuffObject(string id)
    {
        return _buffSetter.GetBuffWithId(id);
    } 
    public Buff Create(string id)
    {
        var buff = _buffSetter.GetBuffWithId(id);

        return Object.Instantiate(buff);
    }
}
