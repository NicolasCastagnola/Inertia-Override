using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon 
{
    public abstract void ChangeWeapon(Weapon w);
    public abstract void Shoot();
    public virtual Weapon CancelDecorator()
    {
        return this;
    }
}
