using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : Prototype, IPoolable<Bullet>
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] protected int damageToUnits;

    [HideInInspector] public float direction;
    [HideInInspector] private float _speed = 5;
    [HideInInspector] public Rigidbody _rigidbody;

    protected Transform _target;
    protected int boundsMaskLayer;
    protected List<IAdvance<BulletBeahaviour>> behaviours = new List<IAdvance<BulletBeahaviour>>();
    protected IAdvance<BulletBeahaviour> currentBehaviour;

    public abstract void OnReset();
    public abstract void ReturnToPool();
    public abstract void TurnOn(Bullet bullet);
    public abstract void TurnOff(Bullet bullet);
    protected virtual void MoveWithBehaviour()
    {
        currentBehaviour.Advance();
    }

    protected void OnAwake()
    {
        IAdvance<BulletBeahaviour> lockon= new LockOn(transform,_target,_speed);
        behaviours.Add(lockon) ;
    }

    #region BUILDERS
    public override Prototype Clone()
    {
        return this;
    }
    public Bullet SetDamage(int amount)
    {
        damageToUnits = amount;
        return this;
    }
    public Bullet SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
        return this;
    }
    public Bullet SetPosition(Vector3 pos)
    {
        transform.position = pos;
        return this;
    }

    public Bullet SetTarget(Transform target)
    {
        _target = target;

        return this;
    }
    public Bullet SetBehaviour(BulletBeahaviour beahaviour)
    {
       currentBehaviour = behaviours.Find(x => x.Equals(beahaviour));

        return this;
    }

    public Bullet SetSpeed(float speed)
    {
        _speed = speed;

        return this;
    }
    public Bullet SetDirection(Vector3 dir)
    {
        _rigidbody.velocity = dir * _speed;
        return this;
    }

    public Bullet SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
        return this;
    }
    public Bullet SetScale(float sizeInAllAxis)
    {
        transform.localScale = new Vector3(sizeInAllAxis, sizeInAllAxis, sizeInAllAxis);
        return this;
    }
    #endregion
}
