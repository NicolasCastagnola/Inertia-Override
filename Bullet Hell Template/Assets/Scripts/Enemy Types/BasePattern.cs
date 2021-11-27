using System.Collections;
using UnityEngine;
public class BasePattern : IPattern
{
    private const float RADIUS = 1f;   

    private readonly PatternFlyweight _patternFlyweight;
    
    //Pattern
    private Transform _transform;
    private int _numberOfProjectiles;            
    private float _projectileSpeed;             
    private int _rotatingAngle;
    private int _angleModifier;
    //Bullet
    private BulletBeahaviour _beahaviour;
    private int _bulletSpeed;
    private int _bulletScale;

    public BasePattern(PatternFlyweight patternFlyweight, Transform transform)
    {
        _transform = transform;
        _patternFlyweight = patternFlyweight;

        InitializeRandomValues();
    }

    public void InitializeRandomValues()
    {
        _beahaviour = _patternFlyweight.spawnBehaviour;
        _numberOfProjectiles = Random.Range(_patternFlyweight.minProjectileQuantity, _patternFlyweight.maxProjectileQuantity);
        _angleModifier = Random.Range(_patternFlyweight.minMultiplier, _patternFlyweight.maxMultiplier);
        _projectileSpeed = Random.Range(_patternFlyweight.minProjectileSpeed, _patternFlyweight.maxProjectileSpeed);
        _rotatingAngle = Random.Range(_patternFlyweight.minInitialRotation, _patternFlyweight.maxInitialRotation);
        _bulletScale = Random.Range(_patternFlyweight.minSize, _patternFlyweight.maxSize);
        _bulletSpeed = Random.Range(_patternFlyweight.minProjectileSpeed, _patternFlyweight.maxProjectileSpeed);

    }

    public void PatternDrawr()
    {
        int angleStep = 360 / _numberOfProjectiles;

        Vector3 _startPoint = _transform.position;

        _rotatingAngle += _angleModifier;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = _startPoint.x + Mathf.Sin((_rotatingAngle * Mathf.PI) / 180) * RADIUS;
            float projectileDirYPosition = _startPoint.y + Mathf.Cos((_rotatingAngle * Mathf.PI) / 180) * RADIUS;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - _startPoint).normalized * _projectileSpeed;
            Vector3 projectileDir = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);


            PoolManager.Instance.hostileBullets.GetObject().SetPosition(_transform.position)
                                                           .SetDirection(projectileDir)
                                                           .SetBehaviour(_beahaviour)
                                                           .SetSpeed(_bulletSpeed)
                                                           .SetScale(_bulletScale);



            _rotatingAngle -= angleStep;
        }
    }

    public void PlayPattern()
    {
        PatternDrawr();
    }
}
