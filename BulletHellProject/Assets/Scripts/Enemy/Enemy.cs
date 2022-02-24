using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : HostileEntity, IRewindable
{
    [SerializeField] public Transform target;
    [SerializeField] private Image[] lives;
    protected int UnitHealth { get { return _enemyController.UnitHealth; } }

    private EnemyModel _enemyModel;
    private EnemyController _enemyController;
    private EnemyView _enemyView;

    protected Buff dropableBuff;
    private int counter = 3;
    protected MementoState memento;

    protected virtual void InitializeEntity(Animator animator, int minHealth, int maxHealth, float maxSpeed, float defaultSpeed, bool isBoss = false)
    {
        OnSpawn();  

        _enemyModel = new EnemyModel(transform, target, minHealth, maxHealth, maxSpeed, defaultSpeed, IsDead);
        _enemyController = new EnemyController(_enemyModel);
        _enemyView = new EnemyView(animator, lives);

        _enemyController.OnAwake();

        if (isBoss)
        {
            memento = new MementoState();
            _enemyModel.OnLifePercetageFlag += _enemyView.RefreshLivesUI;
            _enemyModel.OnLifePercetageFlag += OnPercentageFlag;
            counter = 3;
        }

        _enemyModel.OnDamage += _enemyView.PlayDamage;
        _enemyModel.OnDamage += _enemyView.PlayDamage;
        _enemyModel.OnHeal += _enemyView.PlayHeal;
        _enemyModel.OnDeath += OnDeath;
    }
    protected virtual void OnUpdate() { _enemyController.OnUpdate();}
    public override void TakeDamage(int dmg) { GameManager.Instance.AddScore(pointsForDamagingThisUnit); _enemyController.OnDamage(dmg);  }
    public override void TakeHeal(int heal) { _enemyController.OnHeal(heal); }
    protected virtual void OnDeath() { GameManager.Instance.AddScore(pointsForKillingThisUnit); _enemyView.PlayDeath(); Die();  }
    protected virtual void BringGameObjectToMyPosition(GameObject gameObject)
    {
        gameObject.transform.position = transform.position;
    }
    public virtual void OnPercentageFlag(int lives)
    {
        if (lives != counter)
        {
            counter--;
            EventManager.TriggerEvent(EventType.OnCheckpointSave);  
        }
    }
    public virtual void SetUnitHealth(int amount)
    {
        _enemyController.ModifyHealth(amount);
    }
    public override Prototype Clone() { return this; }
    public abstract void ResetAllBuilders();
    public abstract void Die();
    public abstract void OnRewind(ParamsMemento wrappers);
    public abstract void SaveMementoParamerters();
    public abstract void OnSpawn();
    public virtual void Action()
    {
        if (memento.MemoriesQuantity() <= 0)
            return;

        OnRewind(memento.Remember());
    }

    #region Builders
    public Enemy SetSpeed(float speed)
    {
        _currentSpeed = speed;
        return this;
    }
    public Enemy SetBuffToDrop(Buff buff)
    {
        dropableBuff = buff;

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