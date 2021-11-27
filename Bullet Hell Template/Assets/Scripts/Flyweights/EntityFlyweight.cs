using UnityEngine;

public class EntityFlyweight
{
    public int minHealth;
    public int maxHealth;
    public float maxSpeed;
    public float defaultSpeed;
    public float fireRate;
    public float bulletSpeed;
    public Color bulletColor;
    public MonoBehaviour monoBehaviour;
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