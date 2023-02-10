using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemyFactory 
{
    
    [SerializeField] private EnemySetter enemySetter;

    public EnemyFactory(EnemySetter buffSetter)
    {
        enemySetter = buffSetter;
    }

    public Enemy Create(string id)
    {
        var enemy = enemySetter.GetBuffWithId(id);

        return Object.Instantiate(enemy);
    }
}
