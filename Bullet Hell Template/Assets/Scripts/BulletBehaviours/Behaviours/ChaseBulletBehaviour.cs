using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBulletBehaviour : IAdvance<BulletBeahaviour>
{
    Vector3 _target;
    Vector3 _position;
    float _distanceToStopTracking;
    float _speed;
    public ChaseBulletBehaviour(Vector3 target, Vector3 myPos)
    {
        _target = target;
        _position = myPos;
    }
    public void Advance()
    {
        Seek();
    }

    public void Seek()
    {
        if (Vector3.Distance(_position, _target) < _distanceToStopTracking)
        {
            Vector3 dir = _position - _target;
            dir.Normalize();
            _position += dir * Time.deltaTime * _speed;
        }
    }
}
