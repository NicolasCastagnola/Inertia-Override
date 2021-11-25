using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlliedEntity : MonoBehaviour, IEntity<AlliedEntity>
{
    [HideInInspector] public int CurrentHealth {get {return _currentHealth;}}
    [HideInInspector] public bool IsDead {get {return _isDead;}}
    [HideInInspector] public bool CanShoot {get {return _canShoot;}}

    protected private int _currentHealth;
    protected private bool _isDead;
    protected private bool _canShoot = true;
    protected private float currentSpeed = 1f;

    [Header("Health Properties")]
    [SerializeField] protected int minHealth = 0;
    [SerializeField] protected int maxHealth = 100;

    [Header("Speed Properties")]
    [SerializeField] protected float maxSpeed = 1f;
    [SerializeField] protected float defaultSpeed = 1f;

    public abstract void TakeDamage(int dmg);
    public abstract void TakeHeal(int heal);
}
