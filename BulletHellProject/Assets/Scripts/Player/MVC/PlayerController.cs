using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseEntityController<int>
{
    public int GetCurrentHealth { get { return _model.CurrentHealth; } }

    private PlayerModel _model;

    public PlayerController(PlayerModel model)
    {
        _model = model;
    }
    public override void OnDamage(int amount) { _model.TakeDamage(amount);  }
    public override void OnHeal(int amount){ _model.TakeHeal(amount); }
    public async void MakeInvinsible(float time)
    {
        await _model.MakeInvulnerable(time);
    }
    public void Inputs()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _model.SetNormalFire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _model.SetEnhanced();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _model.SetUltra();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _model.Shoot();
        }
    }
    public override void OnUpdate()
    {
        //_model.MoveWithCursor();
        if (Mathf.Abs(Input.GetAxisRaw(_model.horizontal)) > 0.5f) _model.MoveHorizontal(_model.horizontal);
        if (Mathf.Abs(Input.GetAxisRaw(_model.vertical)) > 0.5f) _model.MoveVertical(_model.vertical);
        Inputs();
    }

    public void ChangeCurrentWeapon(Weapon w)
    {
    }
    public void ModifyHealth(int health)
    {
        _model.SetHealth(health);
    }
    public override void OnAwake()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnEnable()
    {
        _model.SetNormalFire();
    }

    public override void OnStart()
    {
        //throw new System.NotImplementedException();
    }

    public override void DisableEntity()
    {
        
    }
}
