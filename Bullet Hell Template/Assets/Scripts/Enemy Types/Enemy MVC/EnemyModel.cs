using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : BaseEntityModel
{
    public IAdvance<EnemiesBehaviours> currentStrategy;

    private Transform _target;

    public event Action<int> OnHealthValueModified;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    //public event Action OnShoot;

    public EnemyModel(Transform transform, Transform target, PoolManager spawner, int minHealth, int maxHealth, float maxSpeed, float defaultSpeed, bool isDead)
    {
        _transform = transform;
        _target = target;
        _spawner = spawner;
        _isDead = isDead;
        _minLife = minHealth;
        _maxLife = maxHealth;
        _maxSpeed = maxSpeed;
        _defaultSpeed = defaultSpeed;

        _currentSpeed = _defaultSpeed;
        _currentHealth = _maxLife;

    }
    public void SetDefaultSpeed()
    {
        _currentSpeed = _defaultSpeed;
    }
    public override void TakeDamage(int amount)
    {
        if (_currentHealth <= _minLife) Die();

        else _currentHealth -= amount; OnHealthValueModified?.Invoke(_currentHealth); OnDamage?.Invoke();
    }
    public override void Die()
    {
        _isDead = true;
        OnDeath?.Invoke();
    }
    public override void TakeHeal(int amount)
    {
        if (_currentHealth >= _maxLife) _currentHealth = _maxLife;

        else _currentHealth += amount; OnHealthValueModified?.Invoke(_currentHealth); OnHeal?.Invoke();
    }

    public void Move()
    {
        if (!IsDead && currentStrategy != null) 
        {
            currentStrategy.Advance();
        }
    }
}
