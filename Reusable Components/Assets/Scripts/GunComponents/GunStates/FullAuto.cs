using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAuto : FireMode
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

    private void OnEnable()
    {
        StartCoroutine(Delay());
        _playerActions = new PlayerActions();
        _playerActions.PlayerMap.Fire.Enable();
    }

    private void OnDisable()
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
        yield return new WaitForSeconds((60 / Firerate));
        _cooldown = false;
    }

    private void Update()
    {
        if (_gunBase.GunHandler == null || _gunBase.Ammo <= 0 || _gunBase.Reloading)
            return;

        if (_playerActions.PlayerMap.Fire.IsPressed())
            Fire();
    }
}
