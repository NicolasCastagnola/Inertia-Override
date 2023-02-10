using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAdvance : IAdvance<EnemiesBehaviours>
{
    Transform _transform, _target;
    float _speed;

    public TargetAdvance(Transform transform, Transform target, float speed)
    {
        _transform = transform;
        _target = target;
        _speed = speed;
    }

    public void Advance()
    {
        _transform.position += (_target.position - _transform.position).normalized * _speed * Time.deltaTime;
    }
}

public class TargetSinuosAdvance : IAdvance<EnemiesBehaviours>
{
    Transform _transform, _target;
    float _frequency;
    float _amplitude;

    public TargetSinuosAdvance(Transform transform, Transform target, float frequency, float amplitude)
    {
        _transform = transform;
        _target = target;
        _frequency = frequency;
        _amplitude = amplitude;
    }

    public void Advance()
    {
        _transform.position = _transform.position + _transform.up * Mathf.Sin(Time.time * _frequency) * _amplitude;
        _transform.position = Vector3.MoveTowards(_transform.position, _target.transform.position, 0.1f);
    }
}


#region Boss Behaviours
public class RandomAdvanceInsideColliderBounds : IAdvance<EnemiesBehaviours>
{
    Transform _transform;
    Vector3 _target = Vector3.zero;
    BoxCollider _collider;
    float _speed;
    public RandomAdvanceInsideColliderBounds(Transform transform, float speed, BoxCollider collider)
    {
        _transform = transform;
        _collider = collider;
        _speed = speed;
    }
    public void Advance()
    {
        if (_target == Vector3.zero)
        {
            _target = GetRandomPointInCollider();
        }

        if (Vector3.Distance(_transform.position, _target) <= 0.2)
        {
            _target = Vector3.zero;
        }

        _transform.position += (_target - _transform.position).normalized * _speed * Time.deltaTime;
    }

    Vector3 GetRandomPointInCollider()
    {
        Vector3 bounds = _collider.size / 2f;
        Vector3 point = new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y), 0f);

        return _collider.transform.TransformPoint(point);
    }
}

public class Idle : IAdvance<EnemiesBehaviours>
{
    public void Advance()
    {

    }
}
#endregion