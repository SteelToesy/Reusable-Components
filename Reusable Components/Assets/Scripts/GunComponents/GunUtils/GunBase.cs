using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField] protected PlayerActions _playerActions;
                     
    [SerializeField] protected Transform _bulletSpawnpoint;
    [SerializeField] protected GameObject _bullet;
                     
    [SerializeField] protected string _name;
    [SerializeField] protected int _gunCost;
                     
    [SerializeField] protected float _damage;
    [SerializeField] protected float _firerate;
                     
    [SerializeField] protected float _reloadTime;

    [SerializeField] protected float _stashMaxAmmo;
    [SerializeField] protected float _stashAmmo;
    [SerializeField] protected float _maxAmmo;
    [SerializeField] protected float _ammo;

    public string Name => _name;

    public int GunCost => _gunCost;
    public float Damage => _damage;

    public float Ammo => _ammo;

    public float StashAmmo => _stashAmmo;

    private void Awake()
    {
        _playerActions = new PlayerActions();
        _ammo = _maxAmmo;
        _stashMaxAmmo = _stashAmmo;
    }

    private void OnEnable()
    {
        _playerActions.PlayerMap.ToggleFirerate.Enable();
        _playerActions.PlayerMap.Fire.Enable();
        _playerActions.PlayerMap.Reload.Enable();
        _playerActions.PlayerMap.Fire.performed += Fire_performed;
        _playerActions.PlayerMap.Reload.performed += Reload_performed;
        _playerActions.PlayerMap.ToggleFirerate.performed += ToggleFirerate_performed;
    }

    private void OnDisable()
    {
        _playerActions.PlayerMap.ToggleFirerate.Disable();
        _playerActions.PlayerMap.Fire.Disable();
        _playerActions.PlayerMap.Reload.Disable();
        _playerActions.PlayerMap.Fire.performed -= Fire_performed;
        _playerActions.PlayerMap.Reload.performed -= Reload_performed;
        _playerActions.PlayerMap.ToggleFirerate.performed -= ToggleFirerate_performed;
    }

    public void ConnectToPlayer()
    {
        if (!GetComponent<GunHandler>())
            return;

        GunHandler gunHandler = GetComponent<GunHandler>();
        _bulletSpawnpoint = gunHandler.BulletSpawnPoint;
        _bullet = gunHandler.Bullet;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
        bullet.transform.SetParent(transform, true);
    }

    public bool CanReload()
    {
        if (_ammo != _maxAmmo && _stashAmmo != 0)
            return true;
        else return false;
    }

    public IEnumerator ReloadCommand()
    {
        if (CanReload())
        {
            yield return new WaitForSeconds(_reloadTime);
            _ammo = ReloadAmmo();
        }
    }

    public float ReloadAmmo()
    {
        float ammo = 0;
        float loadedAmmo = _ammo;
        for (int i = 0; i < _maxAmmo; i++, loadedAmmo++, ammo++, _stashAmmo--)
        {
            if (loadedAmmo == _maxAmmo)
                return loadedAmmo;

            if (ammo + _ammo == _maxAmmo)
                return ammo + _ammo;

            if (_stashAmmo == 0)
                return ammo;
        }
        return ammo;
    }

    public void ToggleFirerate()
    {
        //states
    }

    public void RefillAmmo()
    {
        _stashAmmo = _stashMaxAmmo;
    }

    public void Enable()
        => this.enabled = true;

    public void Disable()
        => this.enabled = false;

    public void Fire_performed(InputAction.CallbackContext obj)
    {
        if (_bulletSpawnpoint)
            Shoot();
    }

    private void Reload_performed(InputAction.CallbackContext obj)
    {
        StartCoroutine(ReloadCommand());
    }

    private void ToggleFirerate_performed(InputAction.CallbackContext obj)
    {
        ToggleFirerate();
    }
}
