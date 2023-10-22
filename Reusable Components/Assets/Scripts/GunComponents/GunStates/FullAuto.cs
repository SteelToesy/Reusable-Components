using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAuto : FireMode
{
    [SerializeField] private int _bulletConsumption;
    public override int BulletConsumption => _bulletConsumption;

    [SerializeField] private float _firerate;
    public override float Firerate => _firerate;

    [SerializeField] private GunBase _gunBase;
    public override GunBase ThisBase => _gunBase;

    bool cooldown = false;

    public override void Initialize(GunBase pGunBase)
    {
        _gunBase = pGunBase;
        _playerActions = new PlayerActions();

        _playerActions.PlayerMap.Fire.Enable();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds((60 / Firerate));
        cooldown = false;
    }

    [SerializeField] private PlayerActions _playerActions;

    public override void Fire()
    {
        Debug.Log("works");
        if (!cooldown)
        {
            cooldown = true;
            ThisBase.BulletsFired(BulletConsumption);
            ThisBase.SpawnBullet();
            StartCoroutine(Delay());
        }
    }

    private void OnDisable()
    {
        _playerActions.PlayerMap.Fire.Disable();
    }

    private void Update()
    {
        if (_gunBase.GunHandler == null || _gunBase.Ammo <= 0)
            return;
        if (_playerActions.PlayerMap.Fire.IsPressed())
        {
            Fire();
        }
    }
}
