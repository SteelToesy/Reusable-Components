using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private int _currentGun = 0;
    [SerializeField] private Component[] _guns = new Component[2];
    [SerializeField] private GameObject _bullet; //temp?
    [SerializeField] private Transform _bulletSpawnpoint;

    public GameObject Bullet => _bullet;

    public Transform BulletSpawnPoint => _bulletSpawnpoint;

    private void Awake()
    {
        _playerActions = new PlayerActions();
    }

    private void OnEnable()
    {
        _playerActions.PlayerMap.SwitchWeapon.Enable();
        _playerActions.PlayerMap.SwitchWeapon.performed += SwitchWeapon_performed;
    }

    private void OnDisable()
    {
        _playerActions.PlayerMap.SwitchWeapon.Disable();
        _playerActions.PlayerMap.SwitchWeapon.performed -= SwitchWeapon_performed;
    }

    public void AddGun(GunBase pGun)
    {
        gameObject.AddComponent(pGun.GetType());
        for (int i = 0; i < _guns.Length; i++)
            if (_guns[i] == null)
            {
                _guns[i] = GetComponent(pGun.GetType());
                if (i == 1) EnableOnlyCurrent();
                return;
            }
        ReplaceGun(GetComponent(pGun.GetType()));
        EnableOnlyCurrent();
    }

    public void ReplaceGun(Component pGun)
    {
        Destroy(GetComponent(_guns[_currentGun].GetType()));
        _guns[_currentGun] = pGun;
    }

    void EnableOnlyCurrent()
    {
        if (_guns[1] == null)
            return; 
        foreach(GunBase gun in _guns)
        {
            if (gun != _guns[_currentGun])
                gun.Disable();
            else 
                gun.Enable();
        }
    }

    private void SwitchWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_guns.Length - 1 == _currentGun)
            _currentGun = 0;
        else
            _currentGun++;

        EnableOnlyCurrent();
    }
}
