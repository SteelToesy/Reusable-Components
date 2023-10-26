using System.Collections;
using UnityEngine;
using System.Threading;
using System;
using System.Collections.Generic;
using TMPro;

public class SemiAuto : FireMode
{
    [SerializeField] private string _name;
    public override string Name => _name;
    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private int _bulletConsumption;
    public override int BulletConsumption => _bulletConsumption;

    [SerializeField] private float _firerate;
    public override float Firerate => _firerate;

    [SerializeField] private GunBase _gunBase;
    public override GunBase ThisBase => _gunBase;

    [SerializeField] private bool _cooldown = false;
    public override bool Cooldown => _cooldown;

    public void OnEnable()
    {
        StartCoroutine(Delay());
        _playerActions = new PlayerActions();
        _playerActions.PlayerMap.Fire.Enable();
        _playerActions.PlayerMap.Fire.performed += Fire_performed;
    }

    public void OnDisable()
    {
        _playerActions.PlayerMap.Fire.Disable();
    }


    public override void Initialize(GunBase pGunBase)
    {
        _gunBase = pGunBase;
    }

    public override void Fire()
    {
        if (!_cooldown)
        {
            _cooldown = true;
            ThisBase.BulletsFired(BulletConsumption);
            ThisBase.SpawnBullet();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(60 / Firerate);
        _cooldown = false;
    }

    public void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gunBase.GunHandler == null || _gunBase.Ammo <= 0 || _gunBase.Reloading)
            return;
        Fire();
        Debug.Log(_gunBase.Name + " Firing");
    }
}