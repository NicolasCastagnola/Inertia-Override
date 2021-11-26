using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseEntityController<int>
{
    private PlayerModel _model;

    public PlayerController(PlayerModel model)
    {
        _model = model;
    }
    public override void OnDamage(int amount) { _model.TakeDamage(amount);  }
    public override void OnHeal(int amount){ _model.TakeHeal(amount); }
    public void Inputs()
    {
        /*
        if (Mathf.Abs(Input.GetAxisRaw(_model.horizontal)) > 0.5f)
        {
            _model.MoveHorizontal(_model.horizontal);
        }
        if (Mathf.Abs(Input.GetAxisRaw(_model.vertical)) > 0.5f)
        {
            _model.MoveVertical(_model.vertical);
        }
        */
        _model.MoveWithCursor();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _model.Shoot();
        }
    }
    public override void OnUpdate()
    {
        if (!_model.IsDead)
        {
            Inputs();
        }
    }

    public void ChangeCurrentWeapon(Weapon w)
    {
        _model.currentSelectedWeapon = w;
    }
    public override void OnAwake()
    {
        _model.currentSelectedWeapon = new NormalFire(_model.Middle);
    }

    public override void OnEnable()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnStart()
    {
        //throw new System.NotImplementedException();
    }
}
