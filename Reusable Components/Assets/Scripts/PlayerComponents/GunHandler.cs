using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private GameObject _currentGun;
    [SerializeField] private GameObject[] _guns = new GameObject[2];

    [SerializeField] private GameObject _holder;
    [SerializeField] private SpriteRenderer _holderRenderer;


    //public GunBase Gun
    //{
    //    get { return _gunBases[_currentGun];  }
    //}

    //public GameObject Bullet => _bullet;

    public Transform BulletSpawnPoint => _holder.transform;

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
        //for (int i = 0; i < _guns.Length; i++)
        //    if (_guns[i] == null)
        //    {
        //        _currentGun = i;
        //        SetGunValues(i, pGun, pGunTexture);
        //        break;
        //    }
        //ReplaceGun(pGun, pGunTexture);
        //_holderRenderer.sprite = _gunTextures[_currentGun];
        //EnableOnlyCurrent();
    }

    public void ReplaceGun(GameObject pGun, Sprite pGunTexture)
    {
        //Destroy(GetComponent(_guns[_currentGun].GetType()));
        //SetGunValues(_currentGun, pGun, pGunTexture);
    }

    void SetGunValues(int value, GameObject pGun, Sprite pGunTexture)
    {
        //var gun = gameObject.AddComponent(pGun.GetType());
        //_gunTextures[value] = pGunTexture;
        //_guns[value] = pGun;
        //_gunBases[value] = (GunBase)gun;
    }

    void EnableOnlyCurrent()
    {
        //_holder.GetComponent<SpriteRenderer>().sprite = _gunTextures[_currentGun];
        //if (_guns[1] == null)
        //    return; 
        //foreach(GunBase gun in _gunBases)
        //{
        //    if (gun != _guns[_currentGun])
        //        gun.Disable();
        //    else 
        //        gun.Enable();
        //}
    }

    private void SwitchWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //if (_guns[1] == null)
        //    return;
        //if (_guns.Length - 1 == _currentGun)
        //    _currentGun = 0;
        //else
        //    _currentGun++;

        //EnableOnlyCurrent();
    }
}
