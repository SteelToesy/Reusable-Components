using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : FireMode
{
    [SerializeField] private PlayerActions _playerActions;

    [SerializeField] private int _bulletConsumption;
    public override int BulletConsumption => _bulletConsumption;

    [SerializeField] private float _firerate;
    public override float Firerate => _firerate;

    [SerializeField] private int _bulletsInBurst;
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
        int i = 0;
        while (i <_bulletsInBurst){
            if (!_cooldown)
            {
                i++;
                _cooldown = true;
                ThisBase.BulletsFired(BulletConsumption);
                ThisBase.SpawnBullet();
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(60 / Firerate);
        _cooldown = false;
    }

    public void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gunBase.GunHandler == null || _gunBase.Ammo <= 0)
            return;
        Fire();
        Debug.Log(_gunBase.Name + " Firing");
    }
}
