using System.Collections;
using UnityEngine;
public class BasePattern : IPattern
{
    private const float RADIUS = 1f;   

    private readonly PatternFlyweight _patternFlyweight;
    
    private Transform _transform;
    private Transform _target;
    private int _numberOfProjectiles;            
    private float _projectileSpeed;             
    private int _rotatingAngle;
    private int _angleModifier;
    private BulletBeahaviour _beahaviour;
    private int _bulletSpeed;
    private int _bulletScale;

    public BasePattern(PatternFlyweight patternFlyweight, Transform transform, Transform target)
    {
        _transform = transform;
        _target = target;
        _patternFlyweight = patternFlyweight;

        InitializeRandomValues();
    }

    void InitializeRandomValues()
    {
        _beahaviour = _patternFlyweight.spawnBehaviour;
        _numberOfProjectiles = Random.Range(_patternFlyweight.minProjectileQuantity, _patternFlyweight.maxProjectileQuantity);
        _angleModifier = Random.Range(_patternFlyweight.minMultiplier, _patternFlyweight.maxMultiplier);
        _projectileSpeed = Random.Range(_patternFlyweight.minProjectileSpeed, _patternFlyweight.maxProjectileSpeed);
        _rotatingAngle = Random.Range(_patternFlyweight.minInitialRotation, _patternFlyweight.maxInitialRotation);
        _bulletScale = Random.Range(_patternFlyweight.minSize, _patternFlyweight.maxSize);
        _bulletSpeed = Random.Range(_patternFlyweight.minProjectileSpeed, _patternFlyweight.maxProjectileSpeed);

    }

    void PatternDrawr()
    {
        int angleStep = 360 / _numberOfProjectiles;

        Vector3 _startPoint = _transform.position;

        _rotatingAngle += _angleModifier;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = _startPoint.x + BossPatterns.sinLookAtTable.ReturnValue(_rotatingAngle) * RADIUS;
            float projectileDirYPosition = _startPoint.y + BossPatterns.cosLookAtTable.ReturnValue(_rotatingAngle) * RADIUS;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - _startPoint).normalized * _projectileSpeed;
            Vector3 projectileDir = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);


            BulletPoolManager.Instance.hostileBullets.GetObject().SetPosition(_transform.position)
                                                           .SetDirection(projectileDir)
                                                           .SetTarget(_target)
                                                           .SetBehaviour(_beahaviour)
                                                           .SetSpeed(_bulletSpeed)
                                                           .SetScale(_bulletScale)
                                                           .SetColor(Color.red);



            _rotatingAngle -= angleStep;
        }
    }

    public void PlayPattern()
    {
        PatternDrawr();
    }
}
