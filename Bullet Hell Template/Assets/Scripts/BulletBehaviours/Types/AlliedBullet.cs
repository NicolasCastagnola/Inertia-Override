using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedBullet : Bullet
{
    [SerializeField] private int damageToHostileUnits;

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
        //do on reset
    }

    public override void ReturnToPool()
    {
        PoolManager.Instance.alliedBullets.ReturnObject(this);
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
        IEntity<HostileEntity> entity = other.GetComponent<IEntity<HostileEntity>>();

        if (entity!=null)
        {
            entity.TakeDamage(damageToHostileUnits);
            ReturnToPool();
        }
        if (other.gameObject.layer == boundsMaskLayer)
        {
            ReturnToPool();
        }
    }
}
