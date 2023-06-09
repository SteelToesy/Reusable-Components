using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunBase : MonoBehaviour
{
    [SerializeField]protected PlayerActions _actions;

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
        _actions = new PlayerActions();
    }

    public void ConnectToPlayer()
    {
        GunHandler gunHandler = GetComponent<GunHandler>();
        _bulletSpawnpoint = gunHandler.BulletSpawnPoint;
        _bullet = gunHandler.Bullet;
    }

    public IEnumerator Shoot()
    {
        if (_ammo <= 0 || _reloading)
            yield return null;
        else
        {
            _ammo--;
            Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
        }
        yield return new WaitForSeconds(1 / (_firerate/60)); // implement firerate further
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
        Shoot();
    }

    private void Reload_performed(InputAction.CallbackContext obj)
    {
        if (!_reloading)
            StartCoroutine(Reload());
    }

    private void OnEnable()
    {
        _actions.PlayerMap.Enable();
        _actions.PlayerMap.Fire.performed += Fire_performed;
        _actions.PlayerMap.Reload.performed += Reload_performed;
    }

    private void OnDisable()
    {
        _actions.PlayerMap.Disable();
        _actions.PlayerMap.Fire.performed -= Fire_performed;
        _actions.PlayerMap.Reload.performed -= Reload_performed;
    }
}
