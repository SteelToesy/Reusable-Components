using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp40 : GunBase
{
    public Mp40()
    {
        _name = "MP-40";
        _gunCost = 1400;

        _allowFullAuto = true;
        _damage = 6;
        _firerate = 1600;

        _reloadTime = 2;

        _stashAmmo = 320;
        _maxAmmo = 30;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}
