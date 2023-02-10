using UnityEngine;

public class BulletFlyweight
{
    public float bulletSpeed;
    public Color bulletColor;
}
public class ConvoyFlyweight
{
    public string PatternID;
    public string EnemyTypeID;
    public EnemiesBehaviours unitBeheviorType;
    public float spawnTickRate;
    public int minQuantity;
    public int maxQuantity;
}
public class PatternFlyweight 
{
    public BulletBeahaviour spawnBehaviour;
    public int minInitialRotation;
    public int maxInitialRotation;
    public int minMultiplier;
    public int maxMultiplier;
    public int minProjectileQuantity;
    public int maxProjectileQuantity;
    public int minProjectileSpeed;
    public int maxProjectileSpeed;
    public int minSize;
    public int maxSize;
}