using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class PlayerModel : BaseEntityModel 
{
    //String Input Const
    public readonly string horizontal = "Horizontal";
    public readonly string vertical = "Vertical";

    public List<Weapon> _weapons;
    private int currentSelectedWeaponIndex;
    private Weapon currentSelectedWeapon;
    MonoBehaviour _behaviourWorkAround;

    private List<Transform> _transforms;

    //Events
    public event Action<int> OnHealthValueModified;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnShoot;
    public event Action OnRewind;

    public PlayerModel(int minxHealth, int maxHealth, float fireRate, float defaultSpeed, Transform transform, bool canShoot, bool isDead, BulletPoolManager spawner, List<Transform> transforms , List<Weapon> weapons, MonoBehaviour behaviourWorkAround)
    {
        _minLife = minxHealth;
        _maxLife = maxHealth;
        _weapons = weapons;
        _fireRate = fireRate;
        _spawner = spawner;
        _transform = transform;
        _transforms = transforms;
        _isDead = isDead;
        _canShoot = canShoot;
        _behaviourWorkAround = behaviourWorkAround;

        SetSpeed(defaultSpeed);
        SetHealth(_maxLife);

    }
    public override void Die()
    {
        _isDead = true;
        OnDeath?.Invoke();
    }
    public void SetNormalFire()
    {
        currentSelectedWeapon = new NormalFire(_transforms[0]);
    }
    public void SetUltra()
    {
        currentSelectedWeapon = new MegaUltraFire(currentSelectedWeapon, _transforms);
    }
    public void SetEnhanced()
    {
        currentSelectedWeapon = new EnhancedFire(currentSelectedWeapon, _transforms);
    }
    public override void TakeDamage(int amount)
    {
        if (!IsDead)
        {
            if (!_isInvulnerable)
            {
                _currentHealth -= amount;
                OnHealthValueModified?.Invoke(_currentHealth); 
                OnDamage?.Invoke();
            }

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

    #region WebGL Work Around

    public void ShootWebGL()
    {
        if (_canShoot)
        {
            currentSelectedWeapon.Shoot();
            OnShoot?.Invoke();
            _behaviourWorkAround.StartCoroutine(ShootWait());
        }
    }

    IEnumerator ShootWait()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_fireRate);

        _canShoot = true;
    }

    #endregion

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
    public void SetHealth(int amount)
    {
        _currentHealth = amount;
        _isDead = false;
        OnHealthValueModified?.Invoke(_currentHealth);
    }
    public void SetSpeed(float amount)
    {
        _currentSpeed = amount;

        OnRewind?.Invoke();
    }
    private async Task WaitFireRate()
    {
        _canShoot = false;

        var secondsToMiliseconds = _fireRate * 1000;

        await Task.Delay((int)secondsToMiliseconds);

        _canShoot = true;
    }
    public async Task MakeInvulnerable(float timer)
    {
        _isInvulnerable = true;

        var secondsToMiliseconds = timer * 1000;

        await Task.Delay((int)secondsToMiliseconds);

        _isInvulnerable = false;
    }
}
