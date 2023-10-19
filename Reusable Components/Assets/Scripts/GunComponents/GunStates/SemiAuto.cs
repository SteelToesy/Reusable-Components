using System.Collections;
using UnityEngine;
using System.Threading;
using System;
using System.Collections.Generic;

public class SemiAuto : FireMode
{
    [SerializeField] private int _bulletConsumption;
    public override int BulletConsumption => _bulletConsumption;

    [SerializeField] private float _firerate;
    public override float Firerate => _firerate;
    [SerializeField] private GunBase _gunBase;
    public override GunBase ThisBase => _gunBase;

    [SerializeField] private ShootStateBase _currentState;
    [SerializeField] private ShootStateBase _fireringState;
    public override ShootStateBase FireringState => _fireringState;
    [SerializeField] private ShootStateBase _canfireState;
    public override ShootStateBase CanfireState => _canfireState;


    public override void SetBase(GunBase pGunBase) => _gunBase = pGunBase;

    public override void ChangeState(ShootStateBase pState) => _currentState = pState;

    private void Awake()
    {
        gameObject.AddComponent<Canfire>();
        gameObject.AddComponent<Firering>();
        _canfireState = GetComponent<Canfire>();
        _fireringState = GetComponent<Firering>();
        _currentState =  _canfireState;
    }

    public override void UpdateState()
    {
        Debug.Log(_currentState);
        _currentState.UpdateState(this);
    }

    public class Firering : ShootStateBase
    {
        private bool firering = false;
        public override void UpdateState(FireMode pFireMode)
        {
            StartCoroutine(Delay(pFireMode));
            if (firering)
                pFireMode.ChangeState(pFireMode.CanfireState);
        }

        private IEnumerator Delay(FireMode pFireMode)
        {
            yield return new WaitForSeconds((60 / pFireMode.Firerate));
            firering = true;
        }
    }
    public class Canfire : ShootStateBase
    {
        public override void UpdateState(FireMode pFireMode)
        {
            pFireMode.ThisBase.BulletsFired(pFireMode.BulletConsumption);
            pFireMode.ThisBase.SpawnBullet();
        pFireMode.ChangeState(pFireMode.FireringState);
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
