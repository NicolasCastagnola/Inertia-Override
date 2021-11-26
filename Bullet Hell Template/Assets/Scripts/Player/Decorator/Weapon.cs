using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon 
{
    public string g;
    public abstract void ChangeWeapon(Weapon w);
    public abstract Bullet Shoot();
    public virtual Weapon CancelDecorator()
    {
        return this;
    }
}
