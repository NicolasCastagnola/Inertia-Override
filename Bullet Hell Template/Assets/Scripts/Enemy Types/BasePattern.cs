using System.Collections;
using UnityEngine;
public class BasePattern : IPattern, IPrototype
{
    private const float RADIUS = 1f;   
 
    private Transform _unitPos;
    private BulletBeahaviour _bulletBeahaviour;
    private int _numberOfProjectiles = 5;            
    private float _projectileSpeed = 1f;             
    private int _rotatingAngle = 0;
    private int _angleModifier = 0;
    private float _size;

    #region Builders
    public BasePattern SetSpawnPoint(Transform unitPos)
    {
        _unitPos = unitPos;

        return this;
    }
    public BasePattern SetProjectileQuantity(int numberOfProjectiles )
    {
        _numberOfProjectiles = numberOfProjectiles;
        return this;
    }
    public BasePattern SetProjectileSpeed(float projectileSpeed)
    {
        _projectileSpeed = projectileSpeed;
        return this;
    }
    public BasePattern SetAngleMultiplier(int angle)
    {
        _angleModifier = angle;
        return this;
    }
    public BasePattern SetInitialRotationInDegrees(int rotatingAngle = 0)
    {
        _rotatingAngle = rotatingAngle;
        return this;
    }
    public BasePattern SetSize(float size)
    {
        _size = size;
        return this;
    }
    public BasePattern SetBehaviour(BulletBeahaviour beahaviour)
    {
        _bulletBeahaviour = beahaviour;
        return this;
    }

    #endregion
    public void BasePatternBehaviuor()
    {
        int angleStep = 360 / _numberOfProjectiles;

        Vector3 _startPoint = _unitPos.position;
        _rotatingAngle += _angleModifier;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = _startPoint.x + Mathf.Sin((_rotatingAngle * Mathf.PI) / 180) * RADIUS;
            float projectileDirYPosition = _startPoint.y + Mathf.Cos((_rotatingAngle * Mathf.PI) / 180) * RADIUS;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - _startPoint).normalized * _projectileSpeed;
            Vector3 projectileDir = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);

            var bullet = PoolManager.Instance.hostileBullets.GetObject();

                bullet.SetPosition(_startPoint).
                       SetScale(_size).
                       SetSpeed(_projectileSpeed).
                       SetDirection(projectileDir).
                       SetColor(Color.red).
                       SetBehaviour(_bulletBeahaviour);
                                                                    
            _rotatingAngle -= angleStep;
        }
    }

    public void Pattern()
    {
        BasePatternBehaviuor();
    }

    public IPrototype Clone()
    {
        return this;
    }
}
