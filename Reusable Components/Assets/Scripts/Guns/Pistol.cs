using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GunBase
{
    public Pistol()
    {
        _allowFullAuto = false;
        _damage = 2;
        _firerate = 240;

        _reloadTime = 3;

        _maxAmmo = 7;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}
