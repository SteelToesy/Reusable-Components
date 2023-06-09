using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunBase : MonoBehaviour
{
    [SerializeField]protected PlayerActions _playerActions;

    [SerializeField]protected Texture2D _texture;
    [SerializeField]protected Transform _bulletSpawnpoint;
    [SerializeField]protected GameObject _bullet;

    [SerializeField]protected float _damage;
    [SerializeField]protected float _firerate;

    [SerializeField]protected bool _reloading = false;
    [SerializeField]protected float _reloadTime;
    [SerializeField]protected float _currentReloadingTime;

    [SerializeField]protected float _maxAmmo;
    [SerializeField]protected float _ammo;

    private void Awake()
    {
        _playerActions = new PlayerActions();
    }

    private void OnEnable()
    {
        _playerActions.PlayerMap.Fire.Enable();
        _playerActions.PlayerMap.Reload.Enable();
        _playerActions.PlayerMap.Fire.performed += Fire_performed;
        _playerActions.PlayerMap.Reload.performed += Reload_performed;
    }

    private void OnDisable()
    {
        _playerActions.PlayerMap.Fire.Disable();
        _playerActions.PlayerMap.Reload.Disable();
        _playerActions.PlayerMap.Fire.performed -= Fire_performed;
        _playerActions.PlayerMap.Reload.performed -= Reload_performed;
    }

    public void ConnectToPlayer()
    {
        GunHandler gunHandler = GetComponent<GunHandler>();
        _bulletSpawnpoint = gunHandler.BulletSpawnPoint;
        _bullet = gunHandler.Bullet;
    }

    public IEnumerator Shoot()
    {
        if (_ammo > 0 && !_reloading)
        {
            _ammo--;
            Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
            yield return new WaitForSeconds(60 / _firerate); // implement firerate further
        }
    }

    public IEnumerator Reload()
    {
        //TODO: reload fuction now whack

        _reloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _ammo = _maxAmmo;
        _reloading = false;
    }

    public void Fire_performed(InputAction.CallbackContext obj)
    {
        StartCoroutine(Shoot());
    }

    private void Reload_performed(InputAction.CallbackContext obj)
    {
        if (!_reloading || _ammo != _maxAmmo)
            StartCoroutine(Reload());
    }
}
