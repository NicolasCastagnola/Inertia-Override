using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStaticFlyweightPointers 
{
    public static readonly PatternFlyweight Circle = new PatternFlyweight
    {
        spawnBehaviour = BulletBeahaviour.None,
        minInitialRotation = 0,
        maxInitialRotation = 0,
        minMultiplier = 0,
        maxMultiplier = 0,
        minProjectileQuantity = 10,
        maxProjectileQuantity = 50,
        minProjectileSpeed = 2,
        maxProjectileSpeed = 5,
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


}
