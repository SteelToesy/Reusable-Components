using System.Collections;
using UnityEngine;
using System.Threading;
using System;
using System.Collections.Generic;

public class SemiAuto : FireMode
{
    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private int _bulletConsumption;
    public override int BulletConsumption => _bulletConsumption;

    [SerializeField] private float _firerate;
    public override float Firerate => _firerate;

    [SerializeField] private GunBase _gunBase;
    public override GunBase ThisBase => _gunBase;

    bool cooldown = false;

    private void Start()
    {
        _playerActions = new PlayerActions();
        Enable();
    }

    public void Enable()
    {
        _playerActions.PlayerMap.Fire.Enable();
        _playerActions.PlayerMap.Fire.performed += Fire_performed;
    }

    public void OnDisable()
    {
        _playerActions.PlayerMap.Fire.Disable();
        _playerActions.PlayerMap.Fire.performed -= Fire_performed;
    }


    public override void Initialize(GunBase pGunBase)
    {
        _gunBase = pGunBase;
    }

    public override void Fire()
    {
        if (!cooldown)
        {
            cooldown = true;
            ThisBase.BulletsFired(BulletConsumption);
            ThisBase.SpawnBullet();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds((60 / Firerate));
        cooldown = false;
    }

    public void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gunBase.GunHandler == null || _gunBase.Ammo <= 0)
            return;
        Fire();
    }
}