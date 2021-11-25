using UnityEngine;
using System;
using System.Collections;

public class PlayerModel : BaseEntityModel 
{
    Transform _middle, _left, _right;
    //String Input Const
    public readonly string horizontal = "Horizontal";
    public readonly string vertical = "Vertical";

    //Events
    public event Action<int> OnHealthValueModified;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnShoot;

    public PlayerModel(int minHealth, int maxHealth, float slowedSpeed, float defaultSpeed, float fireRate ,Transform transform, bool canShoot, bool isDead, PoolManager spawner, MonoBehaviour monoBehaviour, Transform middle, Transform left, Transform right)
    {
        _minLife = minHealth;
        _maxLife = maxHealth;
        _fireRate = fireRate;
        _spawner = spawner;
        _monoBehaviour = monoBehaviour;
        _slowedSpeed = slowedSpeed;
        _defaultSpeed = defaultSpeed;
        _transform = transform;
        _middle = middle;
        _left = left;
        _right = right;
        _isDead = isDead;

        _canShoot = canShoot;
        _currentSpeed = _defaultSpeed;
        _currentHealth = _maxLife;
    }
    public override void Die()
    {
        _isDead = true;
        OnDeath?.Invoke();
    }
    public override void TakeDamage(int amount)
    {
        if (!IsDead)
        {
            _currentHealth -= amount;
            OnHealthValueModified?.Invoke(_currentHealth); 
            OnDamage?.Invoke();

            if (_currentHealth <= _minLife)
            {
                Die();
            }

        }

    }
    public override void TakeHeal(int amount)
    {
        if (_currentHealth >= _maxLife) _currentHealth = _maxLife;

        else _currentHealth += amount; OnHealthValueModified?.Invoke(_currentHealth); OnHeal?.Invoke();
    }
    public void MoveHorizontal(string h)
    {
        _transform.Translate(new Vector3(Input.GetAxisRaw(h) * _currentSpeed * Time.deltaTime, 0, 0));
    }
    public void MoveVertical(string v)
    {
        _transform.Translate(new Vector3(0, Input.GetAxisRaw(v) * _currentSpeed * Time.deltaTime, 0));
    }

    public void MoveWithCursor()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        _transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void Shoot()
    {
        if (_canShoot)
        {
            AlliedBullet bullet = _spawner.alliedBullets.GetObject();

            bullet.SetPosition(_middle.position).SetSpeed(FlyweightPointer.Player.bulletSpeed).SetDirection(_transform.up).SetColor(FlyweightPointer.Player.bulletColor);
                   
            OnShoot?.Invoke();

            _monoBehaviour.StartCoroutine(WaitFireRate());
        }
    }
    private IEnumerator WaitFireRate()
    {
        _canShoot = false;
        
        yield return new WaitForSeconds(_fireRate);

        _canShoot = true;
    }
}
