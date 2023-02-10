using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFactoryManager : MonoBehaviour
{
    [SerializeField] private BuffSetter buffSetter;

    private BuffFactory _buffFactory;
    public static BuffFactoryManager Instance { get { return _instance; } }
    private static BuffFactoryManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;

        _buffFactory = new BuffFactory(Instantiate(buffSetter));
    }
    private void OnDisable()
    {
        _instance = null;
    }

    public Buff GetBuff(string id)
    {
        return _buffFactory.SetBuffObject(id);
    }

    public Buff SpawnBuff(string id)
    {
        return _buffFactory.Create(id);
    }
}
