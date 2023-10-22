using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using System.Collections.Generic;
using System;

public class GunBase : MonoBehaviour
{
    [SerializeField] private GunHandler _gunhandler;
    public GunHandler GunHandler => _gunhandler;

    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private List<FireMode> modes;
    [SerializeField] private FireMode _currentMode;
    [SerializeField] private Transform _bulletSpawnpoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private string _name;
    [SerializeField] private int _gunCost;
    [SerializeField] private float _damage;
    [SerializeField] private float _stashMaxAmmo;
    [SerializeField] private float _stashAmmo;
    [SerializeField] private float _maxAmmo;
    [SerializeField] private float _ammo;
    [SerializeField] private float _reloadTime;

    public string Name => _name;

    public int GunCost => _gunCost;

    public float Damage => _damage;

    public float Ammo => _ammo;

    public float StashAmmo => _stashAmmo;

    private void Start()
    {
        _playerActions = new PlayerActions();

        _playerActions.PlayerMap.Reload.Enable();
        _playerActions.PlayerMap.ToggleFirerate.Enable();
        _playerActions.PlayerMap.Reload.performed += Reload_performed;
        _playerActions.PlayerMap.ToggleFirerate.performed += ToggleFirerate_performed;
    }

    private void OnDisable()
    {
        _playerActions.PlayerMap.Reload.Disable();
        _playerActions.PlayerMap.ToggleFirerate.Disable();
        _playerActions.PlayerMap.Reload.performed -= Reload_performed;
        _playerActions.PlayerMap.ToggleFirerate.performed -= ToggleFirerate_performed;

    }

    public void Initialize()
    {
        modes = gameObject.GetComponents<FireMode>().ToList();
        modes.ForEach(mode => mode.Initialize(this));
        _ammo = _maxAmmo;
        _stashMaxAmmo = _stashAmmo;
        _currentMode = modes.First();
    }

    public void ConnectGunHandler(GunHandler pHandler) {
        _gunhandler = pHandler;
        Debug.Log(_gunhandler);
    } 

    public void SpawnBullet()
    {
        GameObject bullet = Instantiate(_bullet, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
        bullet.transform.SetParent(transform, true);
    }

    public void BulletsFired(int pAmount)
    {
        _ammo -= pAmount;
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

    public void ToggleFireMode()
    {

    }

    public void RefillAmmo()
    {
        _stashAmmo = _stashMaxAmmo;
    }

    private void Reload_performed(InputAction.CallbackContext obj)
    {
        if (CanReload())
            StartCoroutine(ReloadCommand());
    }

    private void ToggleFirerate_performed(InputAction.CallbackContext obj)
    {
        ToggleFireMode();
    }
}
