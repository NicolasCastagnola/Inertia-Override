using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerModel : BaseEntityModel 
{
    //String Input Const
    public readonly string horizontal = "Horizontal";
    public readonly string vertical = "Vertical";

    public Weapon currentSelectedWeapon;
    public Transform Middle { get { return _middle; } }
    public Transform _middle, _left, _right;

    //Events
    public event Action<int> OnHealthValueModified;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnShoot;
    public event Action<Weapon> OnWeaponChanged;

    public PlayerModel(int minHealth, int maxHealth, float slowedSpeed, float defaultSpeed, float fireRate, Transform transform, bool canShoot, bool isDead, PoolManager spawner, Transform middle, Transform left, Transform right, Weapon weapon)
    {
        _minLife = minHealth;
        _maxLife = maxHealth;
        _fireRate = fireRate;
        _spawner = spawner;
        _slowedSpeed = slowedSpeed;
        _defaultSpeed = defaultSpeed;
        _transform = transform;
        _middle = middle;
        _left = left;
        _right = right;
        currentSelectedWeapon = weapon;
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
    public async void Shoot()
    {
        if (_canShoot)
        {
            currentSelectedWeapon.Shoot();
            
            OnShoot?.Invoke();

            await WaitFireRate();
        }
    }

    public void ChangeWeapon(Weapon w)
    {
        currentSelectedWeapon = w;   
    }
    private async Task WaitFireRate()
    {
        _canShoot = false;

        var secondsToMiliseconds = _fireRate * 1000;

        await Task.Delay((int)secondsToMiliseconds);

        _canShoot = true;
    }
}
