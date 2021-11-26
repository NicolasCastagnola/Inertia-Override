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
        defaultSpeed = 1f,
        maxSpeed = 10f,
        maxHealth = 150,
        minHealth = 0,
        bulletSpeed = 40f,
        bulletColor = Color.red,
        fireRate = 0.1f
    };

    public static readonly Flyweight Seeker = new Flyweight
    {
        defaultSpeed = 5f,
        maxSpeed = 10f,
        maxHealth = 20,
        minHealth = 0,
        bulletSpeed = 10f,
        bulletColor = Color.blue,
        fireRate = 1f
    };

    public static readonly Flyweight Bomber = new Flyweight
    {
        defaultSpeed = 2f,
        maxSpeed = 10f,
        maxHealth = 10,
        minHealth = 0,
        bulletSpeed = 10f,
        bulletColor = Color.cyan,
        fireRate = 1f
    };
}
