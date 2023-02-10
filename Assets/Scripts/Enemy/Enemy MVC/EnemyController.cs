using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : BaseEntityController<int>
{
    private EnemyModel _model;

    public int UnitHealth { get { return _model.CurrentHealth; } }

    public EnemyController(EnemyModel enemyModel)
    {
        _model = enemyModel;
    }

    public override void OnAwake()
    {
        _model.SetDefaultSpeed();
    }
    public void ModifyHealth(int n)
    {
        _model.SetHealth(n);
    }
    public override void OnDamage(int a)
    {
        _model.TakeDamage(a);
    }
    public override void OnHeal(int a)
    {
        _model.TakeHeal(a);
    }

    public void SetCurrentStrategy(IAdvance<EnemiesBehaviours> advance)
    {
        _model.currentStrategy = advance;
    }

    public override void OnEnable()
    {
    }
    public override void OnStart()
    {
        _model.SetDefaultSpeed();
    }
    public override void OnUpdate()
    {
        _model.Move();
    }
    
    public override void DisableEntity()
    {
        _model.Die();
    }
}
