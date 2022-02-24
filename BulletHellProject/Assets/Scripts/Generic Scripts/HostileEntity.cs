using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class HostileEntity : Prototype, IEntity<HostileEntity>
{
    [Header("Global Settings")]
    [SerializeField] private string _id;
    public int pointsForDamagingThisUnit;
    public int pointsForKillingThisUnit;
    public string ID => _id;
    [Header("Visual Properties")]
    [SerializeField] protected Sprite[] sprites;

    [Header("Health Properties")]
    [SerializeField] protected int minHealth = 0;
    [SerializeField] protected int maxHealth = 100;

    [Header("Speed Properties")]
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float defaultSpeed;
    
    [HideInInspector] public int CurrentHealth {get{return _currentHealth;}}
    protected int _currentHealth;

    [HideInInspector] public bool IsDead {get{return _isDead;}}
    protected bool _isDead;

    [HideInInspector] public float CurrentSpeed { get { return _currentSpeed; } }
    protected float _currentSpeed;

    private MementoState memento;

    public abstract void TakeDamage(int dmg);
    public abstract void TakeHeal(int heal);
    public abstract void TerminateEntity();

}
