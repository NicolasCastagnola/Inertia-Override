using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFire : Weapon
{
    Transform _middle;
    public NormalFire(Transform middle)
    {
        _middle = middle;
    }

    public override Weapon CancelDecorator()
    {
        return this;
    }


    public override void ChangeWeapon(Weapon w)
    {
    }

    public override void Shoot()
    {
        PoolManager.Instance.alliedBullets.GetObject().SetPosition(_middle.position).SetSpeed(FlyweightPointer.Player.bulletSpeed).SetDirection(_middle.up).SetColor(FlyweightPointer.Player.bulletColor);
    }


    /*
    public override Bullet Shoot()
    {
        return PoolManager.Instance.alliedBullets.GetObject().SetPosition(_middle.position).SetSpeed(FlyweightPointer.Player.bulletSpeed).SetDirection(_middle.up).SetColor(FlyweightPointer.Player.bulletColor);
    }
    */
}
