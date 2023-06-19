using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunBase : MonoBehaviour
{
    [SerializeField] protected PlayerActions _playerActions;
                     
    [SerializeField] protected Transform _bulletSpawnpoint;
    [SerializeField] protected GameObject _bullet;
                     
    [SerializeField] protected string _name;
                     
    [SerializeField] protected bool _fullAuto = false;
    [SerializeField] protected bool _allowFullAuto;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _firerate;
    [SerializeField] protected bool _allowShoot = true; //whacky bools
                     
    [SerializeField] protected bool _reloading = false; //whacky bools
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected float _currentReloadingTime;
                     
    [SerializeField] protected float _stashAmmo;
    [SerializeField] protected float _maxAmmo;
    [SerializeField] protected float _ammo;

    public string Name
    {
        get => _name;
    }
    public float Damage
    {
        get => _damage;
    }

    public float Ammo
    {
        get => _ammo;
    }

    public float StashAmmo
    {
        get => _stashAmmo;
    }

    private void Awake()
    {
        _playerActions = new PlayerActions();
        _ammo = _maxAmmo;
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

    private void Update()
    {
        Fullauto();
    }

    public void ConnectToPlayer()
    {
        if (!GetComponent<GunHandler>())
            return;

        GunHandler gunHandler = GetComponent<GunHandler>();
        _bulletSpawnpoint = gunHandler.BulletSpawnPoint;
        _bullet = gunHandler.Bullet;
    }

    public IEnumerator Shoot()
    {
        if (_allowShoot && _ammo > 0 && !_reloading)
        {
            _allowShoot = false;
            _ammo--;
            GameObject bullet = Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
            bullet.transform.SetParent(transform, true);
            yield return new WaitForSeconds(60 / _firerate);
            _allowShoot = true;
        }
    }

    public bool CanReload()
    {
        if (_ammo != _maxAmmo && !_reloading && _stashAmmo != 0)
            return true;
        else return false;
    }

    public IEnumerator Reload()
    {
        if (CanReload())
        {
            _reloading = true;
            yield return new WaitForSeconds(_reloadTime);
            _ammo = ReloadAmmo();
            _reloading = false;
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

    public void Fullauto()
    {
        if (!_fullAuto || !_bulletSpawnpoint)
            return;

        if (_playerActions.PlayerMap.Fire.IsPressed())
            StartCoroutine(Shoot());
    }

    public void ToggleFirerate()
    {
        if (!_allowFullAuto) 
            return;

        if (_fullAuto)
            _fullAuto = false;
        else 
            _fullAuto = true;
    }

    public void Enable()
        => this.enabled = true;

    public void Disable()
        => this.enabled = false;

    public void Fire_performed(InputAction.CallbackContext obj)
    {
        if (_bulletSpawnpoint)
            StartCoroutine(Shoot());
    }

    private void Reload_performed(InputAction.CallbackContext obj)
    {
        StartCoroutine(Reload());
    }

    private void ToggleFirerate_performed(InputAction.CallbackContext obj)
    {
        ToggleFirerate();
    }
}
