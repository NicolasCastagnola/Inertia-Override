using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : BaseEntityModel
{
    public IAdvance<EnemiesBehaviours> currentStrategy;
    private bool sendFlag;

    private Transform _target;

    public event Action<int> OnHealthValueModified;
    public event Action<int> OnLifePercetageFlag;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    public EnemyModel(Transform transform, Transform target, int minHealth, int maxHealth, float maxSpeed, float defaultSpeed, bool isDead)
    {
        _transform = transform;
        _target = target;
        _isDead = isDead;
        _minLife = minHealth;

        _maxLife = maxHealth;
        _maxSpeed = maxSpeed;
        _defaultSpeed = defaultSpeed;

        _currentSpeed = _defaultSpeed;

        SetHealth(_maxLife);

    }
    public void SetDefaultSpeed()
    {
        _currentSpeed = _defaultSpeed;
    }
    public override void TakeDamage(int amount)
    {
        _currentHealth -= amount; OnDamage?.Invoke();

        if (_currentHealth <= 0) Die();

        OnLifePercetageFlag?.Invoke(EvaluateUnitHealthPercentageBasedOnThree());
    }

    public int EvaluateUnitHealthPercentageBasedOnThree()
    {
        if (_currentHealth <= 0) return 0;

        if (_currentHealth <= _maxLife * 0.33f) return 1;

        if (_currentHealth <= _maxLife * 0.66f) return 2;

        else return 3;
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
    public void SetHealth(int amount)
    {
        _currentHealth = amount;

        OnHealthValueModified?.Invoke(_currentHealth);
    }
    public void Move()
    {
        if (!IsDead && currentStrategy != null) 
        {
            currentStrategy.Advance();
        }
    }
}
