using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDecorator : Weapon
{
    protected Weapon _weapon;
    public WeaponDecorator(Weapon w)
    {
        _weapon = w;
    }

    public override Bullet Shoot()
    {
        return _weapon.Shoot();
    }
}

