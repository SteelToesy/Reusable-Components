using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp40 : GunBase
{
    public Mp40()
    {
        _allowFullAuto = true;
        _damage = 6;
        _firerate = 320;

        _reloadTime = 2;

        _maxAmmo = 30;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}