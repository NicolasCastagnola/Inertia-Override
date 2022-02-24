using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedBullet : Bullet
{
    private void Awake()
    {
        boundsMaskLayer = LayerMask.NameToLayer("Bounds");
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public override void OnReset()
    {

    }

    public override void ReturnToPool()
    {
        BulletPoolManager.Instance.alliedBullets.ReturnObject(this);
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
        IEntity<HostileEntity> hostileEntity = other.GetComponent<IEntity<HostileEntity>>();

        if (hostileEntity!=null)
        {
            hostileEntity.TakeDamage(damageToUnits);
            ReturnToPool();
        }
        if (other.gameObject.layer == boundsMaskLayer)
        {
            ReturnToPool();
        }
    }
}
