using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1, T2>
{
    private FactoryMethod _factoryMethod;
    public delegate T2 FactoryMethod(T1 key);

    Dictionary<T1, T2> _table = new Dictionary<T1, T2>();

    public LookUpTable(FactoryMethod newFactory) {_factoryMethod = newFactory; }

    public T2 ReturnValue(T1 key)
    {
        if (_table.ContainsKey(key))
            return _table[key];
        else
        {
            var value = _factoryMethod(key);
            _table.Add(key, value);
            return value;
        }
    }
}
