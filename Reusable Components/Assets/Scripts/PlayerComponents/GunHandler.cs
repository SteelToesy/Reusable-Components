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

    public Transform BulletSpawnPoint => _holder.transform;

    private void Awake()
    {
        _playerActions = new PlayerActions();
        _holderRenderer = _holder.GetComponent<SpriteRenderer>();
        UpdateFields();
    }

    private void Update()
    {
        Debug.Log(_gunsGameObjects[_currentGunIndex]);
        _currentGunBase.Active();
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
        if(GunCountMax >= _gunsGameObjects.Count)
        {
            _gunsGameObjects.Add(pGun);
            _currentGunIndex++;
        }
        else
        {
            _gunsGameObjects.RemoveAt(_currentGunIndex);
            _gunsGameObjects.Add(pGun);
        }

    }

    private void SwitchWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gunsGameObjects.Count == 1)
            return;
        if (_gunsGameObjects.Count == GunCountMax)
            _currentGunIndex = 1;
        else
            _currentGunIndex++;
        UpdateFields();
    }

    public void UpdateFields()
    {
        _currentGunBase = _gunsGameObjects[_currentGunIndex].GetComponent<GunBase>();
        _currentGunRenderer = _gunsGameObjects[_currentGunIndex].GetComponent<SpriteRenderer>();
        _currentGun = _gunsGameObjects[_currentGunIndex];
    }
}
