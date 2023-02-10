using System;
using System.Collections.Generic;
public class ObjectPool<T>
{
    public delegate T FactoryMethod();

    List<T> _currentStock = new List<T>();
    FactoryMethod _factoryMethod;
    Action<T> _turnOnCallback;
    Action<T> _turnOffCallback;

    public ObjectPool(FactoryMethod factory, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 3)
    {
        _factoryMethod = factory;
        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;

        for (int i = 0; i < initialStock; i++)
        {
            var obj = _factoryMethod();
            _turnOffCallback(obj);
            _currentStock.Add(obj);
        }
    }

    public T GetObject()
    {
        var result = default(T);

        if (_currentStock.Count > 0)
        {
            result = _currentStock[0];
            _currentStock.RemoveAt(0);
        }

        else
        {
            result = _factoryMethod();
        }

        _turnOnCallback(result);

        return result;
    }

    public void ReturnObject(T obj)
    {
        _turnOffCallback(obj);
        _currentStock.Add(obj);
    }
}