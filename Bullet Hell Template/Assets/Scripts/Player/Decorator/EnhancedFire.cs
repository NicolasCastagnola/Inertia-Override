using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnhancedFire : WeaponDecorator
{
    float _duration;
    Transform _left;
    Transform _right;

    public EnhancedFire(Weapon w, Transform left, Transform right, float duration) : base(w)
    {
        _left = left;
        _right = right;
        _duration = duration;
        InitiateTimer();
    }

    public override Weapon CancelDecorator()
    {
        return _weapon;
    }

    public override void Shoot()
    {
        _weapon.Shoot();
        PoolManager.Instance.alliedBullets.GetObject().SetPosition(_left.position).SetSpeed(FlyweightPointer.Player.bulletSpeed).SetDirection(_left.up).SetColor(FlyweightPointer.Player.bulletColor);
        PoolManager.Instance.alliedBullets.GetObject().SetPosition(_right.position).SetSpeed(FlyweightPointer.Player.bulletSpeed).SetDirection(_right.up).SetColor(FlyweightPointer.Player.bulletColor);
    }
    public async void InitiateTimer()
    {
        await CancelDecoratorTimer();
    }
    public async Task CancelDecoratorTimer()
    {

        var secondsToMiliseconds = _duration * 1000;

        await Task.Delay((int)secondsToMiliseconds);

        Debug.Log("Cancel");

        CancelDecorator();
    }

    public override void ChangeWeapon(Weapon w)
    {
        _weapon = CancelDecorator();
    }
}
