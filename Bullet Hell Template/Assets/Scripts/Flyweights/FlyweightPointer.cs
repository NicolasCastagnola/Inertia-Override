using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    public static readonly Flyweight Player = new Flyweight
    {
        defaultSpeed = 15f,
        maxSpeed = 10f,
        maxHealth = 3,
        minHealth = 0,
        bulletSpeed = 40f,
        bulletColor = Color.green,
        fireRate = 0.1f
    };

    public static readonly Flyweight Boss = new Flyweight
    {
        defaultSpeed = 15f,
        maxSpeed = 10f,
        maxHealth = 150,
        minHealth = 0,
        bulletSpeed = 40f,
        bulletColor = Color.green,
        fireRate = 0.1f
    };
}
