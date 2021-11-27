﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : AlliedEntity
{
    private PlayerModel _model;
    private PlayerController _controller;
    private PlayerView _view;

    private Animator _animator;
    public PoolManager spawner;

    public float fireRate;

    public Transform middle, left, right;
    public Weapon currentWeapon;

    public Image[] lives;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        EntityFlyweight Player = FlyweightPointer.Player;

        _model = new PlayerModel(Player.minHealth, Player.maxHealth, Player.maxSpeed, Player.defaultSpeed, fireRate, transform, CanShoot, IsDead, spawner, middle, left, right, currentWeapon);
        _controller = new PlayerController(_model);
        _view = new PlayerView(_animator, lives);

        _controller.OnAwake();

        _model.OnHealthValueModified += _view.LivesDisplay;
        _model.OnDamage += _view.PlayDamage;
        _model.OnHeal += _view.PlayHeal;
        _model.OnDeath += _view.PlayDeath;
        _model.OnDeath += Die;
    }

    private void OnEnable()
    {
        _controller.OnEnable();


    }
    private void Start()
    {
        _controller.OnStart();
    }
    private void Update()
    {
        _controller.OnUpdate();


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            var c = new NormalFire(middle);
            var g = new EnhancedFire(c, left, right, 5f);
            ChangeCurrentPlayerWeapon(g);
        }

    }
    public override void TakeDamage(int amount)
    {
        _controller.OnDamage(amount);
    }

    public void ChangeCurrentPlayerWeapon(Weapon weapon)
    {
        _controller.ChangeCurrentWeapon(weapon);
    }

    public override void TakeHeal(int amount) 
    {
        _controller.OnHeal(amount);
    }
    public void Die()
    {
        EventManager.TriggerEvent(EventType.SaveData);
    }

}
