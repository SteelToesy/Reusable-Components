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

    public void AddGun(Component pGun)
    {
        gameObject.AddComponent(pGun.GetType());
        for (int i = 0; i < _guns.Length; i++)
        {
            if (_guns[i] == null)
            {
                _guns[i] = GetComponent(pGun.GetType());
                return;
            }
        }
        ReplaceGun(GetComponent(pGun.GetType()));
    }

    public void ReplaceGun(Component pGun)
    {
        Component temp = GetComponent(_guns[_currentGun].GetType());
        Destroy(temp);
        _guns[_currentGun] = pGun;
    }

    void EnableOnlyCurrent()
    {
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i != _currentGun)
                _guns[i].GetComponent<GunBase>().Disable();
            else
                _guns[i].GetComponent<GunBase>().Enable();
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
