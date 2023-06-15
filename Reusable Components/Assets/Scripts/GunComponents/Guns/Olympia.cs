using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olympia : GunBase
{ 
    public Olympia()
    {
        _allowFullAuto = true;
        _damage = 18;
        _firerate = 120;

        _reloadTime = 4;

        _stashAmmo = 38;
        _maxAmmo = 2;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}
