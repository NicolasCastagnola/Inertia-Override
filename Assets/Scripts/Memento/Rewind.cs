using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rewind : MonoBehaviour
{
    protected MementoState memento;

    public abstract IEnumerator StartToRec();
    protected abstract void BeRewind(ParamsMemento wrappers);

    protected virtual void Awake()
    {
        memento = new MementoState();

        StartCoroutine(StartToRec());
    }

    public void Action()
    {
        if (memento.MemoriesQuantity() <= 0)
            return;

        BeRewind(memento.Remember());
    }
}