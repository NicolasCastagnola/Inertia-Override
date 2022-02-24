using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : IAdvance<BulletBeahaviour>
{
    Transform _target;
    Transform _transform;
    float _speed;

    public Homing(Transform transform, Transform target, float speed)
    {
        _target = target;
        _transform = transform;
        _speed = speed;
    }
    
    public void Advance()
    {
        LockAndGo();
    }

    public void LockAndGo()
    {
        Vector3 dir = _target.position - _transform.position;
        dir.Normalize();

        _transform.position += dir * _speed * Time.deltaTime;
    }
}
