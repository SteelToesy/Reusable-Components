using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olympia : GunBase
{ 
    public Olympia()
    {
        _name = "Olympia";
        _gunCost = 500;

        _allowFullAuto = false;
        _damage = 18;
        _firerate = 600;

        _reloadTime = 4;

        _stashAmmo = 38;
        _maxAmmo = 2;
    }

    private void Start()
    {
        ConnectToPlayer();
    }
}
