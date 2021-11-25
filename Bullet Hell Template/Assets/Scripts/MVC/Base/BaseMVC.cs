using UnityEngine;
public abstract class BaseEntityModel : IModel<int>
{
    protected Transform _transform;
    protected PoolManager _spawner;
    protected MonoBehaviour _monoBehaviour;

    //Health
    public float CurrentHealth { get { return _currentHealth; } }
    protected int _currentHealth;
    protected int _maxLife;
    protected int _minLife;

    //Speed
    public float CurrentSpeed { get { return _currentSpeed; } }
    protected float _currentSpeed;
    protected float _slowedSpeed;
    protected float _maxSpeed;
    protected float _defaultSpeed;

    //Shoot
    protected float _fireRate;

    //Flags
    public bool IsDead { get { return _isDead; } }
    protected bool _isDead = false;
    protected bool _canShoot = true;
    public abstract void TakeHeal(int amount);
    public abstract void TakeDamage(int amount);
    public abstract void Die();
}
public abstract class BaseEntityView
{
    public abstract void PlayAnimationWithName(string animation);
}
public abstract class BaseEntityController<T>
{
    public abstract void OnDamage(T a);
    public abstract void OnHeal(T a);
    //public abstract void OnDeath();
    public abstract void OnAwake();
    public abstract void OnEnable();
    public abstract void OnStart();
    public abstract void OnUpdate();
}
