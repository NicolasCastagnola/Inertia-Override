using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{

    public static readonly BulletFlyweight Player = new BulletFlyweight
    {
        bulletSpeed = 40f,
        bulletColor = Color.green,
    };

    public static readonly BulletFlyweight Boss = new BulletFlyweight
    {
        bulletSpeed = 10f,
        bulletColor = Color.red,
    };
}
