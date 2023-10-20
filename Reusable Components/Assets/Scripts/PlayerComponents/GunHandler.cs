using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private int _currentGunIndex;
    [SerializeField] private GunBase _currentGunBase;
    [SerializeField] private SpriteRenderer _currentGunRenderer;
    [SerializeField] private GameObject _currentGun;
    [SerializeField] private List<GameObject> _gunsGameObjects = new List<GameObject>();
    [SerializeField] private int GunCountMax = 2;

    [SerializeField] private GameObject _holder;
    [SerializeField] private SpriteRenderer _holderRenderer;

    public GunBase Gun => _currentGunBase;

    private void Awake()
    {
        _playerActions = new PlayerActions();
        _holderRenderer = _holder.GetComponent<SpriteRenderer>();
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
        if(GunCountMax > _gunsGameObjects.Count)
        {
            _gunsGameObjects.Add(pGun);
            if (_gunsGameObjects.Count == 1)
                _currentGunIndex = 0;
            else
                _currentGunIndex++;
        }
        else
        {
            _gunsGameObjects.RemoveAt(_currentGunIndex);
            _gunsGameObjects.Add(pGun);
        }
        UpdateFields(_gunsGameObjects[_currentGunIndex]);
        _currentGunBase.ConnectGunHandler(this);
    }

    private void SwitchWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gunsGameObjects.Count == 1)
            return;
        if (_gunsGameObjects.Count == GunCountMax)
            _currentGunIndex = 1;
        else
            _currentGunIndex++;
        UpdateFields(_gunsGameObjects[_currentGunIndex]);
    }

    public void UpdateFields(GameObject pGun)
    {
        _currentGunBase = pGun.GetComponent<GunBase>();
        _currentGunRenderer = pGun.GetComponent<SpriteRenderer>();
        _currentGun = pGun;
    }
}
