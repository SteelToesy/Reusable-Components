using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private PlayerActions _playerActions;
    public PlayerActions Playeractions { get { return _playerActions; } }

    [SerializeField] private int _currentGunIndex;
    [SerializeField] private GunBase _currentGunBase;
    [SerializeField] private GameObject _currentGun;
    [SerializeField] private List<GameObject> _gunsGameObjects = new List<GameObject>();
    [SerializeField] private int GunCountMax = 2;


    public GunBase Gun => _currentGunBase;

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

    public void AddGun(GameObject pGun, Sprite pGunTexture)
    {
        GameObject gun = Instantiate(pGun, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z + -0.1f), Quaternion.identity, transform);
        gun.AddComponent<Aiming>();
        if (GunCountMax > _gunsGameObjects.Count)
        {
            _gunsGameObjects.Add(gun);
            if (_gunsGameObjects.Count == 1)
                _currentGunIndex = 0;
            else
                _currentGunIndex++;
        }
        else
        {
            _gunsGameObjects.RemoveAt(_currentGunIndex);
            _gunsGameObjects.Add(gun);
        }
        UpdateFields(_gunsGameObjects[_currentGunIndex]);
        _currentGunBase.ConnectGunHandler(this);
    }

    public void UpdateFields(GameObject pGun)
    {
        _currentGunBase = pGun.GetComponent<GunBase>();
        _currentGun = pGun;
    }

    private void SwitchWeapon_performed(InputAction.CallbackContext obj)
    {
        if (_gunsGameObjects.Count == 1)
            return;
        if (_gunsGameObjects.Count == GunCountMax)
            _currentGunIndex = 1;
        else
            _currentGunIndex++;
        UpdateFields(_gunsGameObjects[_currentGunIndex]);
    }
}
