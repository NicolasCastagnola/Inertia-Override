using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NonStaticFlyweightPointers 
{
    public static readonly PatternFlyweight LinearLockOn = new PatternFlyweight
    {
        spawnBehaviour = BulletBeahaviour.LockOn,
        minInitialRotation = 180,
        maxInitialRotation = 180,
        minMultiplier = 0,
        maxMultiplier = 0,
        minProjectileQuantity = 1,
        maxProjectileQuantity = 1,
        minProjectileSpeed = 2,
        maxProjectileSpeed = 2,
        minSize = 3,
        maxSize = 3
    };

    public static readonly PatternFlyweight Circle = new PatternFlyweight
    {
        spawnBehaviour = BulletBeahaviour.None,
        minInitialRotation = 0,
        maxInitialRotation = 0,
        minMultiplier = 0,
        maxMultiplier = 0,
        minProjectileQuantity = 10,
        maxProjectileQuantity = 30,
        minProjectileSpeed = 2,
        maxProjectileSpeed = 2,
        minSize = 3,
        maxSize = 8
    };

    public static readonly PatternFlyweight CircleSpiral = new PatternFlyweight
    {
        spawnBehaviour = BulletBeahaviour.None,
        minInitialRotation = 0,
        maxInitialRotation = 0,
        minMultiplier = 5,
        maxMultiplier = 10,
        minProjectileQuantity = 10,
        maxProjectileQuantity = 10,
        minProjectileSpeed = 2,
        maxProjectileSpeed = 3,
        minSize = 3,
        maxSize = 6
    };

    public static readonly PatternFlyweight Spiral = new PatternFlyweight
    {
        spawnBehaviour = BulletBeahaviour.None,
        minInitialRotation = 0,
        maxInitialRotation = 0,
        minMultiplier = 5,
        maxMultiplier = 10,
        minProjectileQuantity = 4,
        maxProjectileQuantity = 4,
        minProjectileSpeed = 1,
        maxProjectileSpeed = 1,
        minSize = 3,
        maxSize = 6
    };
}
