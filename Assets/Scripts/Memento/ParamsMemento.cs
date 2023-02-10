using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamsMemento
{
    public object[] parameters;

    public ParamsMemento(params object[] parametersWrappers)
    {
        parameters = new object[parametersWrappers.Length];

        for (int i = 0; i < parametersWrappers.Length; i++)
        {
            parameters[i] = parametersWrappers[i];
        }
    }
}
