using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GunBase
{
    public Pistol()
    {
        _damage = 2;
        _firerate = 2;
        _reloadTime = 0;
        _maxAmmo = 7;
        _ammo = 7;
    }

    private void Update()
    {
        Shoot();
        ConnectToPlayer();
    }
}
