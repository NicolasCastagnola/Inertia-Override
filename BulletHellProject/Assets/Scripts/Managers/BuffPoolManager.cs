using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPoolManager : MonoBehaviour
{
    public static BuffPoolManager Instance { get { return _instance; } }
    private static BuffPoolManager _instance;

    [SerializeField] HealBuff healBuff;
    [SerializeField] Invulnerable invulnerable;

    public ObjectPool<HealBuff> healPool;
    public ObjectPool<Invulnerable> invulerablePool;

    public int initialStock = 5;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;

        healPool = new ObjectPool<HealBuff>(BuffHeal, healBuff.TurnOn, healBuff.TurnOff, initialStock);

        invulerablePool = new ObjectPool<Invulnerable>(BuffInvulerable, invulnerable.TurnOn, invulnerable.TurnOff, initialStock);

    }
    public HealBuff BuffHeal()
    {
        return Instantiate(healBuff, transform);
    }
    public Invulnerable BuffInvulerable()
    {
        return Instantiate(invulnerable, transform);
        //return (Invulnerable)BuffFactoryManager.Instance.SpawnBuff("Invulnerable");
    }

    private void OnDisable()
    {
        _instance = null;
    }

}
