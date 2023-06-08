using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GunBase
{
    public Pistol()
    {
        _damage = 2;
        _firerate = 2;
        _reloadTime = 5;
        _maxAmmo = 2;
        _ammo = _maxAmmo;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}
