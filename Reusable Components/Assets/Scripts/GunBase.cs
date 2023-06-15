using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GunBase : MonoBehaviour
{
    [SerializeField]protected PlayerActions _playerActions;

    [SerializeField]protected Transform _bulletSpawnpoint;
    [SerializeField]protected GameObject _bullet;

    [SerializeField]protected bool _fullAuto = false;
    [SerializeField]protected bool _allowFullAuto;
    [SerializeField]protected float _damage;
    [SerializeField]protected float _firerate;
    [SerializeField]protected bool _allowShoot = true; //whacky bools

    [SerializeField]protected bool _reloading = false; //whacky bools
    [SerializeField]protected float _reloadTime;
    [SerializeField]protected float _currentReloadingTime;

    [SerializeField]protected float _maxAmmo;
    [SerializeField]protected float _ammo;



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
            Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
            yield return new WaitForSeconds(60 / _firerate);
            _allowShoot = true;
        }
    }

    public IEnumerator Reload()
    {
        if (_ammo != _maxAmmo && !_reloading)
        {
            _reloading = true;
            yield return new WaitForSeconds(_reloadTime);
            _ammo = _maxAmmo;
            _reloading = false;
        }
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
