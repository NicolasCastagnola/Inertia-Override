using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnhancedFire : WeaponDecorator
{
    float _duration;
    public EnhancedFire(Weapon w, float duration) : base(w)
    {
        _duration = duration;
        InitiateTimer();
    }

    public override Weapon CancelDecorator()
    {
        return _weapon;
    }

    public override Bullet Shoot()
    {
        base.g += "Mas esto";
        Debug.Log(g);
        return _weapon.Shoot().SetDamage(3);
    }

    public async void InitiateTimer()
    {
        await CancelDecoratorTimer();
    }
    public async Task CancelDecoratorTimer()
    {

        var secondsToMiliseconds = _duration * 1000;

        await Task.Delay((int)secondsToMiliseconds);

        CancelDecorator();
    }

    public override void ChangeWeapon(Weapon w)
    {
    }
}
