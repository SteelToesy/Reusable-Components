using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GunBase
{
    public Pistol()
    {
        _damage = 2;
        _firerate = 60;
        _reloadTime = 2;
        _maxAmmo = 7;
        _ammo = _maxAmmo;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}
