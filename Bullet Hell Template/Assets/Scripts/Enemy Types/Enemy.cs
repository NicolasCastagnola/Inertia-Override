using UnityEngine;
public abstract class Enemy : HostileEntity
{
    [SerializeField] protected Transform target;
    [SerializeField] protected PoolManager spawner;

    private EnemyModel _enemyModel;
    private EnemyController _enemyController;
    private EnemyView _enemyView;

    protected virtual void InitializeEntity(Animator animator, int minHealth, int maxHealth, float maxSpeed, float defaultSpeed)
    {
        _enemyModel = new EnemyModel(transform, target, spawner, minHealth, maxHealth, maxSpeed, defaultSpeed, IsDead);
        _enemyController = new EnemyController(_enemyModel);
        _enemyView = new EnemyView(animator);

        _enemyController.OnAwake();

        _enemyModel.OnDamage += _enemyView.PlayDamage;
        _enemyModel.OnHeal += _enemyView.PlayHeal;
        _enemyModel.OnDeath += OnDeath;
    }
    protected virtual void OnUpdate() { _enemyController.OnUpdate(); }
    public override void TakeDamage(int dmg) { _enemyController.OnDamage(dmg); }
    public override void TakeHeal(int heal) { _enemyController.OnHeal(heal); }
    protected virtual void OnDeath() { _enemyView.PlayDeath(); Die(); }
    public override void ReturnToPool() { PoolManager.Instance.enemyPool.ReturnObject(this); }
    public override Prototype Clone() { return this; }
    public override void OnReset() { ResetAllBuilders(); }
    public abstract void ResetAllBuilders();
    public abstract void Die();

    #region Builders

    public Enemy SetSpeed(float speed)
    {
        _currentSpeed = speed;
        return this;
    }
    
    public Enemy SetPosition(Transform _transform)
    {
        transform.position = _transform.position;
        return this;
    }

    public Enemy SetBehaviour(IAdvance<EnemiesBehaviours> behaviour)
    {
        _enemyController.SetCurrentStrategy(behaviour);
        return this;
    }

    public Enemy SetTarget(Transform target)
    {
        if (!target) return default;
        this.target = target;
        return this;
    }
    #endregion
}