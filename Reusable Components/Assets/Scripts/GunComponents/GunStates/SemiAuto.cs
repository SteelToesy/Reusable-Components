using System.Collections;
using UnityEngine;
using System.Threading;
using System;
using System.Collections.Generic;

public class SemiAuto : IFireMode
{
    [SerializeField] private int _bulletConsumption;
    public int BulletConsumption => _bulletConsumption;

    [SerializeField] private float _firerate;
    public float Firerate => _firerate;
    [SerializeField] private GunBase _gunBase;
    public GunBase ThisBase => _gunBase; 

    [SerializeField] private ShootStateBase _currentState;

    public void SetBase(GunBase pGunBase) => _gunBase = pGunBase;

    public void ChangeState(ShootStateBase pState) => _currentState = pState;

    public void ShootCommand()
    {
        _currentState.Update(this);
    }

    public class Firering : ShootStateBase
    {
        private bool firering = false;
        public override void Update(IFireMode pFireMode)
        {
            StartCoroutine(Delay(pFireMode));
            if (firering)
                pFireMode.ChangeState(new Canfire());
        }

        private IEnumerator Delay(IFireMode pFireMode)
        {
            yield return new WaitForSeconds((60 / pFireMode.Firerate));
        }
    }
    public class Canfire : ShootStateBase
    {
        public override void Update(IFireMode pFireMode)
        {
            pFireMode.ThisBase.BulletsFired(pFireMode.BulletConsumption);
            pFireMode.ThisBase.SpawnBullet();
        pFireMode.ChangeState(new Firering());
        }
    }
}

//if (_allowshoot && _ammo > 0 && !_reloading)
//{
//    _allowshoot = false;
//    _ammo--;
//    gameobject bullet = instantiate(_bullet, _bulletspawnpoint.position, _bulletspawnpoint.rotation);
//    bullet.transform.setparent(transform, true);
//    yield return new waitforseconds(60 / _firerate);
//    _allowshoot = true;
//}

//public void Fullauto()
//{
//    if (!_fullAuto || !_bulletSpawnpoint)
//        return;

//    if (_playerActions.PlayerMap.Fire.IsPressed())
//        StartCoroutine(Shoot());
//}

//public void ToggleFirerate()
//{
//    if (!_allowFullAuto)
//        return;

//    if (_fullAuto)
//        _fullAuto = false;
//    else
//        _fullAuto = true;
//}
