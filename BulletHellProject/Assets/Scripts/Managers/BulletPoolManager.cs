using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { Allied, Hostile }
public class BulletPoolManager : MonoBehaviour
{
    public AlliedBullet alliedbulletPrefab;
    public HostileBullet hostileBulletPrefab;
    public static BulletPoolManager Instance { get { return _instance; } }
    private static BulletPoolManager _instance;

    public ObjectPool<AlliedBullet> alliedBullets;
    public ObjectPool<HostileBullet> hostileBullets;

    public int initialStock;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;
            
        alliedBullets = new ObjectPool<AlliedBullet>(AlliedBulletFactory, alliedbulletPrefab.TurnOn, alliedbulletPrefab.TurnOff, initialStock);
        hostileBullets = new ObjectPool<HostileBullet>(HostileBulletFactory, alliedbulletPrefab.TurnOn, alliedbulletPrefab.TurnOff, initialStock);

    }

    private void OnDisable()
    {
        _instance = null;
    }

    public AlliedBullet AlliedBulletFactory()
    {
        return Instantiate(alliedbulletPrefab, transform); 
    }
    public HostileBullet HostileBulletFactory()
    {
        return Instantiate(hostileBulletPrefab, transform);
    }

}
