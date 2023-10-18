using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp40 : GunBase
{
    private void Start()
    {
        ConnectToPlayer();
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