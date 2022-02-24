using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoState 
{
    Stack<ParamsMemento> _remembers = new Stack<ParamsMemento>();

    public int MemoriesQuantity()
    {
        return _remembers.Count;
    }
    public void Rec(params object[] parameters)
    {
        _remembers.Push(new ParamsMemento(parameters));
    }
    public ParamsMemento Remember()
    {
        return _remembers.Pop();
    }
}
