using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MegaUltraFire : WeaponDecorator
{
    float _duration;
    List<Transform> _spawnPoints;
    public MegaUltraFire(Weapon w, List<Transform> spawnPoints) : base(w)
    {
        _spawnPoints = spawnPoints;
    }

    public override Weapon CancelDecorator()
    {
        return _weapon;
    }

    public override void Shoot()
    {
        _weapon.Shoot();

        foreach (var item in _spawnPoints)
        {
            BulletPoolManager.Instance.alliedBullets.GetObject().SetPosition(item.position).SetSpeed(FlyweightPointer.Player.bulletSpeed).SetDirection(item.up).SetColor(Color.magenta).SetDamage(2).SetScale(6f);
        }
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
        _weapon = CancelDecorator();
    }
}
