using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : AlliedEntity, IObservable<PlayerStates>, IUntargatable
{
    private List<IObserver<PlayerStates>> _allObservers = new List<IObserver<PlayerStates>>();

    private PlayerModel _model;
    private PlayerController _controller;
    private PlayerView _view;

    private Animator _animator;
    public BulletPoolManager spawner;

    public List<Transform> spawnPoints;
    public List<Weapon> weapons;
    public List<IWeapon> weapon2s;

    public Image[] lives;

    #region Obeserver
    public void Subscribe(IObserver<PlayerStates> obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);
    }

    public void Unsubscribe(IObserver<PlayerStates> obs)
    {
        if (_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObservers(PlayerStates action)
    {
        for (int i = 0; i < _allObservers.Count; i++)
            _allObservers[i].Notification(action);
    }
    #endregion

    private void Awake()
    {
        memento = new MementoState();
        _animator = GetComponent<Animator>();

        InizializeEntity(); 

        _controller.OnAwake();

        EventManager.TriggerEvent(EventType.OnGameInitialization);
    }
    private void OnDisable()
    {
        
    }
    private void Start()
    {
        _controller.OnStart();
    }
    private void Update()
    {
        _controller.OnUpdate();
    }
    public override void TakeDamage(int amount)
    {
        _controller.OnDamage(amount);

        if (_controller.GetCurrentHealth == 1) NotifyToObservers(PlayerStates.NeedHeal);
    }
    public void ChangeCurrentPlayerWeapon(Weapon weapon)
    {
        _controller.ChangeCurrentWeapon(weapon);
    }
    public override void TakeHeal(int amount) 
    {
        _controller.OnHeal(amount);
    }
    public void MakeUntargateble(float timer)
    {
        _controller.MakeInvinsible(timer);

    }
    public override void TerminateEntity()
    {
        EventManager.TriggerEvent(EventType.Deafeat);

        gameObject.SetActive(false);

        _model.OnHealthValueModified -= _view.LivesDisplay;
        _model.OnDamage -= _view.PlayDamage;
        _model.OnHeal -= _view.PlayHeal;
        _model.OnDeath -= _view.PlayDeath;
        _model.OnDeath -= TerminateEntity;
    }

    public override void InizializeEntity()
    {
        gameObject.SetActive(true);

        _model = new PlayerModel(minHealth, maxHealth, fireRate, defaultSpeed, transform, CanShoot, IsDead, spawner, spawnPoints, weapons);
        _controller = new PlayerController(_model);
        _view = new PlayerView(_animator, lives);

        _model.OnHealthValueModified += _view.LivesDisplay;
        _model.OnDamage += _view.PlayDamage;
        _model.OnHeal += _view.PlayHeal;
        _model.OnDeath += _view.PlayDeath;
        _model.OnDeath += TerminateEntity;

        _controller.OnEnable();
    }

    #region Memento
    public override void OnRewind(ParamsMemento wrappers)
    {
        transform.position = (Vector3)wrappers.parameters[1];

        InizializeEntity();

        _controller.ModifyHealth((int)wrappers.parameters[0]);
    }

    public override void SaveMementoParamerters()
    {
        memento.Rec(_controller.GetCurrentHealth, transform.position);
    }

    #endregion
}
