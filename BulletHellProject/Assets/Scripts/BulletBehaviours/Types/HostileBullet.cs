using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileBullet : Bullet
{
    private void Awake()
    {
        boundsMaskLayer = LayerMask.NameToLayer("Bounds");
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void OnReset()
    {

    }

    private void Update()
    {
        MoveWithBehaviour();
    }
    public override void ReturnToPool()
    {
        BulletPoolManager.Instance.hostileBullets.ReturnObject(this);
    }

    public override void TurnOff(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public override void TurnOn(Bullet bullet)
    {
        bullet.OnReset();
        bullet.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        IEntity<AlliedEntity> entity = other.GetComponent<IEntity<AlliedEntity>>();

        if (entity != null)
        {
            entity.TakeDamage(damageToUnits);
            ReturnToPool();
        }
        if (other.gameObject.layer == boundsMaskLayer)
        {
            ReturnToPool();
        }
    }
}
